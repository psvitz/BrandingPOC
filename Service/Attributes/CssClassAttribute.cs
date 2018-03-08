using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrandingPOC.Service.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CssVariableAttribute : Attribute
    {
        public string VariableName { get; set; }

        public CssVariableAttribute(string variableName)
        {
            VariableName = variableName;
        }
    }
}
