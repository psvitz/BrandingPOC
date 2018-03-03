using System;
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
            var themeCss = ThemeService.Instance.GetCurrentThemeCSS();

            return Content(themeCss, "text/css");
        }
    }
}
