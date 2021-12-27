using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.FeatureToggles;
using Microsoft.AspNetCore.Mvc;

namespace Unleash.Demo.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ABController : ControllerBase
    {
        private readonly IFeatureToggler _featureToggler;

        public ABController(IFeatureToggler featureToggler)
        {
            _featureToggler = featureToggler;
        }

        [HttpGet]
        public string Get(string userId)
        {
            var variant = _featureToggler.GetVariant(FeatureToggles.AB_Test.ToString(),
                new FeatureToggleContext {UserId = userId});
            return variant;
        }
    }
}
