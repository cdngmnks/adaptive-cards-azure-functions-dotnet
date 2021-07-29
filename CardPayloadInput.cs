using System;
using System.Collections.Generic;
using System.Text;

namespace RenderAdaptiveCard {
    public class CardPayloadInput {
        public IDictionary<string, object> Card { get; set; }
        public IDictionary<string, object> Data { get; set; }
    }
}
