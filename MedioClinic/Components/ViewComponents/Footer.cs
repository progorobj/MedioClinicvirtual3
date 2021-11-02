#define no_suffix

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedioClinic.Components.ViewComponents
{
    public class Footer : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync() => View();
    }
}
