using System;
namespace BrandingPOC
{
    public class CSSConverter
    {
        string cssTemplate = @":root {{
                    --main-color: {0};
                    --font: {1};
                    --font-color: {2};
                    --main-bg-color: {3};
                }}
            ";

        public string ConvertTheme(Theme theme)
        {
            return string.Format(cssTemplate, theme.MainColor, theme.Font, theme.FontColor, theme.MainBGColor);
        }
    }
}
