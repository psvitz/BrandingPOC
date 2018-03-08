using BrandingPOC.Service.Attributes;
using System;
namespace BrandingPOC
{
    public class Theme
    {
        public int ThemeId { get; set; }

        [CssVariableAttribute("--font-color")]
        public string FontColor { get; set; }
        [CssVariableAttribute("--main-color")]
        public string MainColor { get; set; }
        [CssVariableAttribute("--main-bg-color")]
        public string MainBGColor { get; set; }
        [CssVariableAttribute("--font")]
        public string Font { get; set; }
    }
}
