using System;
using System.Diagnostics.Contracts;
using System.Linq;
using BrandingPOC.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace BrandingPOC
{
    public class CustomCssController: Controller
    {
        public CustomCssController(IConverterFactory converterFactory)
        {
            ThemeService.Instance.Converter = converterFactory.Make();
        }

        public ContentResult Index(int themeId)
        {
            var themeCss = "";
            
            if (themeId > 0)
            {
                var savedTheme = ThemeService.Instance.GetThemeCSS(themeId);
                if(savedTheme != null && savedTheme != "")
                {
                    themeCss = savedTheme;
                }
            }

            if(string.IsNullOrEmpty(themeCss))
            {
                themeCss = ThemeService.Instance.GetCurrentThemeCSS();
            }
                

            return Content(themeCss, "text/css");
        }
    }
}
