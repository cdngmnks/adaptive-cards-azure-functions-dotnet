using AdaptiveCards;
using System;
using System.Collections.Generic;
using System.Text;

namespace RenderAdaptiveCard {
    public interface ICard {
        AdaptiveCard Generate();
    }
}
