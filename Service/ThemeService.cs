using System;
using System.Collections.Generic;
using System.Linq;

namespace BrandingPOC
{
    public class ThemeService
    {
        private List<Theme> _themes;
        private Theme _activeTheme;
        private static ThemeService _instance;
        private CSSConverter _converter;

        public static ThemeService Instance
        {
            get
            {
                return _instance ?? (_instance = new ThemeService());
            }
        }

        private ThemeService()
        {
            _converter = new CSSConverter();

            _activeTheme = MakeDefaultTheme();
            _themes = new List<Theme>();
            _themes.Add(_activeTheme);
        }

        public void SaveTheme(Theme theme)
        {
            var existing = _themes.FirstOrDefault(x => x.ThemeId == theme.ThemeId);
            if(existing == null)
            {
                theme.ThemeId = _themes.Max(x=>x.ThemeId) + 1;
                _themes.Add(theme);
            }
            else
            {
                existing.Font = theme.Font;
                existing.FontColor = theme.FontColor;
                existing.MainBGColor = theme.MainBGColor;
                existing.MainColor = theme.MainColor;
            }
        }
        public List<Theme> GetThemes()
        {
            return _themes;
        }

        public Theme GetCurrentTheme()
        {
            return _activeTheme;
        }
        public string GetCurrentThemeCSS()
        {
            return _converter.ConvertTheme(_activeTheme);
        }
        public void SetCurrentTheme(int themeId)
        {
            var existing = _themes.FirstOrDefault(x => x.ThemeId == themeId);
            if (existing != null)
            {
                _activeTheme = existing;
            }
        }


        private Theme MakeDefaultTheme()
        {
            var theme = new Theme();
            theme.ThemeId = 1;
            theme.FontColor = "#000000";
            theme.MainColor = "#000000";
            theme.MainBGColor = "#FFFFFF";
            theme.Font = "Roboto";
            return theme;
        }

    }
}
