using AdaptiveCards;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RenderAdaptiveCard {
    public class BasicCard: ICard {
        private readonly CardPayloadInput _payloadInput;
        public BasicCard(CardPayloadInput payloadInput) {
            _payloadInput = payloadInput;
        }
        public AdaptiveCard Generate() {
            string data = JsonConvert.SerializeObject(_payloadInput.Card);
            return AdaptiveCard.FromJson(data).Card;
        }
    }
}
