using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpinED.Models
{
    public class ModuleCase
    {
        public string ModuleName { get; set; }
        public int PercentCompleted { get; set; }
        public bool isLocked { get; set; }
        public string CaseName { get; set; }
        public string LinkHref { get; set; }
        public bool isPremium { get; set; }
    }
}