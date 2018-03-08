using BrandingPOC.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace BrandingPOC
{
    public class ConverterFactory : IConverterFactory
    {
        private IHostingEnvironment _env;
        private IServiceProvider _services;

        public ConverterFactory(IServiceProvider services, IHostingEnvironment env)
        {
            _services = services;
            _env = env;
        }

        public IConverter Make()
        {
            var agent = CreateUserAgent();

            IConverter converter = null;

            var isIE = Regex.IsMatch(agent, @"Trident/7.*rv:11");

            if (isIE)
            {
                converter = new IECSSConverter(_env);
            }
            else
            {
                converter = new CSSConverter();
            }

            return converter;
        }

        private string CreateUserAgent()
        {
            if (_services == null)
            {
                throw new ArgumentNullException(nameof(_services));
            }

            var context = _services.GetRequiredService<IHttpContextAccessor>().HttpContext;

            var agent = context.Request.Headers["User-Agent"].FirstOrDefault();

            return agent;
        }
    }
}
