using AdaptiveCards;
using AdaptiveCards.Rendering.Html;
using AdaptiveCards.Templating;
using System;
using System.Collections.Generic;
using System.Text;

namespace RenderAdaptiveCard {
    public class CardTemplating : ICard {
        private readonly CardPayloadInput _payloadInput;
        public CardTemplating(CardPayloadInput payloadInput) {
            _payloadInput = payloadInput;
        }

        public AdaptiveCard Generate() {
            var template = new AdaptiveCardTemplate(_payloadInput.Card);
            string card = template.Expand(_payloadInput.Data);

            AdaptiveCardRenderer rendered = new AdaptiveCardRenderer();
            return AdaptiveCard.FromJson(card).Card;
        }
    }
}
