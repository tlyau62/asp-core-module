using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication11.Modules
{
    public class ModuleDescriptor
    {
        public string MainAssembly { get; set; }

        public string Source { get; set; }

        public string RootDir { get; set; }

        public string StartupClass { get; set; }
    }
}
