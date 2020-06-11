using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Unity;
using UnityAddon.Core;
using UnityAddon.Core.Attributes;
using UnityAddon.Core.Bean;
using UnityAddon.Core.BeanDefinition;
using UnityAddon.Core.Context;
using UnityAddon.Core.Util;
using UnityAddon.Core.Util.ComponentScanning;

namespace WebApplication11.Modules
{
    [Configuration]
    public class ModuleConfig
    {
        [Value("{Module.BasePath}")]
        public string ModuleBasePath { get; set; }

        [Dependency]
        public IModuleCollection ModuleCollection { get; set; }

        [Bean]
        public virtual IBeanDefinitionCollection Col()
        {
            var moduleRootPath = Path.Join(Directory.GetCurrentDirectory(), ModuleBasePath);
            var col = new BeanDefinitionCollection();

            ModuleCollection.ImportFromFolder(moduleRootPath);

            foreach (var entry in ModuleCollection)
            {
                var startup = entry.Assembly.GetType(entry.ModuleDescriptor.StartupClass);
                col.AddComponent(startup);
            }

            return col;
        }
    }

}
