using Microsoft.AspNetCore.Hosting;
using System;
namespace BrandingPOC
{
    public class IECSSConverter : IConverter
    {
        private string _templatePath = "";
        private string _cssTemplate = "";
        private IHostingEnvironment _env;
        private string[] _cssVars = { "--main-color", "--font-color", "--main-bg-color" };

        public IECSSConverter(IHostingEnvironment env)
        {
            var webRoot = env.WebRootPath;
            var templateFilePath = System.IO.Path.Combine(webRoot, "branding-base.css");
            _cssTemplate = System.IO.File.ReadAllText(templateFilePath);
        }

        public string ConvertTheme(Theme theme)
        {
            var convertedCss = _cssTemplate;

            foreach(var cssVar in _cssVars)
            {
                switch(cssVar)
                {
                    case "--main-color":
                        convertedCss = convertedCss.Replace("var(" + cssVar + ")",theme.MainColor);
                        break;
                    case "--font-color":
                        convertedCss = convertedCss.Replace("var(" + cssVar + ")",theme.FontColor);
                        break;
                    case "--main-bg-color":
                        convertedCss = convertedCss.Replace("var(" + cssVar + ")",theme.MainBGColor);
                        break;
                }
            }

            return convertedCss;
        }
    }
}
