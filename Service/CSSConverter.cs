using BrandingPOC.Service.Attributes;
using System;
using System.Linq;
using System.Text;

namespace BrandingPOC
{
    public class CSSConverter : IConverter
    {
        public string ConvertTheme(Theme theme)
        {
            var themeVariables = theme.GetType().GetProperties()
                                                .Where(x => 
                                                            x.GetCustomAttributes(typeof(CssVariableAttribute), false).Any()
                                                      );

            StringBuilder cssVariables = new StringBuilder();
            foreach(var themeVar in themeVariables)
            {
                var varName = (CssVariableAttribute)themeVar.GetCustomAttributes(typeof(CssVariableAttribute), false).FirstOrDefault();
                var value = themeVar.GetValue(theme);

                cssVariables.Append($"{varName.VariableName}:{value}");
            }

            var css = $":root{{{cssVariables}}}";

            return css;
        }
    }
}
