using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityAddon.Core.Attributes;

namespace WebApplication11.Modules
{
    [Component]
    public class ModuleLoader
    {
        public IEnumerable<ModuleEntry> Load(string moduleroot)
        {
            return Directory.GetFiles(moduleroot, "appsettings.json", SearchOption.AllDirectories)
                .Select(path =>
                {
                    var config = new ConfigurationBuilder()
                        .AddJsonFile(path, optional: true, reloadOnChange: true)
                        .Build();
                    var descriptor = config.GetSection("Module").Get<ModuleDescriptor>();

                    descriptor.Source = path;

                    descriptor.RootDir = Path.GetDirectoryName(path);

                    return descriptor;
                })
                .Select(descriptor => new ModuleEntry(descriptor));
        }
    }
}
