using AdaptiveCards;
using System;
using System.Collections.Generic;
using System.Text;

namespace RenderAdaptiveCard {
    public static class CardFactory {
        public static ICard Create(CardPayloadInput payload) {
            if (payload.Data != null) {
                return new CardTemplating(payload);
            }
            return new BasicCard(payload);
        }
    }
}
