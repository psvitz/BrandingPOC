using System;
using System.Diagnostics.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BrandingPOC
{
    public class CustomCssController: Controller
    {
        public CustomCssController()
        {
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
