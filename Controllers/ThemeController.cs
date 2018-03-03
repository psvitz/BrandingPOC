using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BrandingPOC.Controllers
{
    [Route("api/[controller]")]
    public class ThemeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("[action]")]
        public Theme GetCurrentTheme()
        {
            return ThemeService.Instance.GetCurrentTheme();
        }

        [HttpGet("[action]")]
        public List<Theme> GetThemes()
        {
            return ThemeService.Instance.GetThemes();
        }
        
        [HttpPost("[action]")]
        public void SetCurrentTheme([FromBody]Theme theme)
        {
            if(theme!=null)
            {
                ThemeService.Instance.SetCurrentTheme(theme.ThemeId);
            }
        }
        
        [HttpPost("[action]")]
        public void SaveTheme([FromBody]Theme theme)
        {
            ThemeService.Instance.SaveTheme(theme);
        }
    }
}
