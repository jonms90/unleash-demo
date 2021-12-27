using System;
using System.Collections.Generic;
using Application;

namespace Unleash.Demo.Infrastructure
{
    public class UnleashClient : IFeatureToggler
    {
        private readonly IUnleash _client;

        public UnleashClient(string apiUrl, string authToken)
        {
            var settings = new UnleashSettings
            {
                AppName = "WebApiDevClient",
                Environment = "development",
                UnleashApi = new Uri(apiUrl),
                CustomHttpHeaders = new Dictionary<string, string>()
                {
                    {"Authorization", authToken}
                },
                SendMetricsInterval = TimeSpan.FromMinutes(1)
            };

            _client = new DefaultUnleash(settings);
        }

        public bool IsEnabled(string featureToggleName)
        {
            return _client.IsEnabled(featureToggleName);
        }

        public bool IsEnabled(string featureToggleName, FeatureToggleContext context)
        {
            var unleashContext = new UnleashContext
            {
                UserId = context.UserId,
                SessionId = context.SessionId,
                Properties = context.Properties
            };

            return _client.IsEnabled(featureToggleName, unleashContext);
        }

        public string GetVariant(string featureToggleName, FeatureToggleContext context)
        {
            var unleashContext = new UnleashContext
            {
                UserId = context.UserId,
                SessionId = context.SessionId,
                Properties = context.Properties
            };

            return _client.GetVariant(featureToggleName)?.Payload?.Value ?? string.Empty;
        }
    }
}
