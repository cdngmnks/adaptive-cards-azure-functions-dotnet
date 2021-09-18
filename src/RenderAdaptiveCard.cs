using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

using AdaptiveCards;
using AdaptiveCards.Rendering;
using AdaptiveCards.Rendering.Html;
using AdaptiveCards.Templating;
using RenderAdaptiveCard.Resources;
using Microsoft.Extensions.Primitives;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace RenderAdaptiveCard
{
    public static class RenderAdaptiveCard
    {
        [FunctionName("RenderAdaptiveCard")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req, ILogger log) {
            log.LogInformation("got request to render card");

            ModelStateDictionary modelState = new ModelStateDictionary();

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            
            CardPayloadInput cardPayloadInput = JsonConvert.DeserializeObject<CardPayloadInput>(requestBody);
            if (cardPayloadInput.Card == null)
            {
                modelState.AddModelError("card", "Card field is required");
                return new BadRequestObjectResult(modelState);
            }

            AdaptiveCardRenderer renderer = new AdaptiveCardRenderer();
            
            StringValues svQueryHostConfig;
            if (req.Query.TryGetValue("hostConfig", out svQueryHostConfig))
            {
                try
                {
                    renderer.HostConfig = AdaptiveHostConfig.FromJson(
                        EmbeddedResourceJsonBase.GetJsonFromEmbeddedResource(string.Format("RenderAdaptiveCard.Resources.HostConfigs.{0}.json", svQueryHostConfig.ToString()))
                    );
                }catch(ArgumentNullException ex)
                {
                    modelState.AddModelError("hostConfig", "provided host config does not exists");
                    return new BadRequestObjectResult(modelState);
                }
                catch(Exception ex)
                {
                    modelState.AddModelError("hostConfig", ex.Message);
                    return new BadRequestObjectResult(modelState);
                }
            }

            ICard cardCreator = CardFactory.Create(cardPayloadInput);
            AdaptiveCard adaptiveCard = cardCreator.Generate();
            
            RenderedAdaptiveCard renderedCard = renderer.RenderCard(adaptiveCard);
            HtmlTag htmlTag = renderedCard.Html;

            return new OkObjectResult(htmlTag.ToString());
        }
    }
}
