using Microsoft.AspNetCore.Mvc.ApplicationParts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace WebApplication11.Modules
{
    public class ModuleEntry
    {
        private Assembly _assembly;

        private ApplicationPart _applicationPart;

        public ModuleEntry(ModuleDescriptor moduleDescriptor)
        {
            ModuleDescriptor = moduleDescriptor;
        }

        public Assembly Assembly => _assembly ??= Assembly.LoadFrom(Path.Join(ModuleDescriptor.RootDir, ModuleDescriptor.MainAssembly));

        public ApplicationPart ApplicationPart => _applicationPart ??= new AssemblyPart(Assembly);

        public ModuleDescriptor ModuleDescriptor { get; }
    }
}
