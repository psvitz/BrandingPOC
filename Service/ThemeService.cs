﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace BrandingPOC
{
    public class ThemeService
    {
        private List<Theme> _themes;
        private Theme _activeTheme;
        
        public IConverter Converter { get; set; }
        private static ThemeService _instance;

        public static ThemeService Instance
        {
            get
            {
                return _instance ??  (_instance = new ThemeService());
            }
        }


        private  ThemeService()
        {
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

        public string GetThemeCSS(int themeId)
        {
            var theme = GetTheme(themeId);

            string css = null;
            if (theme != null)
            {
                css = Converter.ConvertTheme(theme);
            }

            return css;
        }
        public Theme GetTheme(int themeId)
        {
            return _themes.FirstOrDefault(x => x.ThemeId == themeId);
        }
        public Theme GetCurrentTheme()
        {
            return _activeTheme;
        }
        public string GetCurrentThemeCSS()
        {
            return Converter.ConvertTheme(_activeTheme);
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
            theme.FontColor = "#FF0000";
            theme.MainColor = "#00FF00";
            theme.MainBGColor = "#0000FF";
            theme.Font = "Roboto";
            return theme;
        }

    }
}
