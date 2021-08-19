using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace RenderAdaptiveCard.Resources
{
    public class EmbeddedResourceJsonBase
    {
        public static string GetJsonFromEmbeddedResource(string embededResourcePath)
        {
            string json;
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(embededResourcePath))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    json = reader.ReadToEnd();
                }
            }

            return json;
        }
    }
}
