using System.Collections.Generic;

namespace Application
{
    public interface IFeatureToggler
    {
        public bool IsEnabled(string featureToggleName);
        public bool IsEnabled(string featureToggleName, FeatureToggleContext context);
        public string GetVariant(string featureToggleName, FeatureToggleContext context);
    }
}
