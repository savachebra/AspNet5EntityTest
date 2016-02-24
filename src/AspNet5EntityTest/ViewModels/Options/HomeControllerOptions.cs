using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNet5EntityTest.ViewModels.Options
{
    public class HomeControllerOptions
    {
        public string Title { get; set; } = "Options def title";
        public bool ShowInRed { get; set; } = false;
    }
}
