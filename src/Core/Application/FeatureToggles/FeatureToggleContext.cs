using System.Collections.Generic;

namespace Application
{
    public class FeatureToggleContext
    {
        public string UserId { get; set; }
        public string SessionId { get; set; }

        public Dictionary<string, string> Properties { get; set; } = new();
    }
}
