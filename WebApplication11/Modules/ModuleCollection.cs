using System;
using System.Collections.Generic;
using System.Text;
using Unity;
using UnityAddon.Core.Attributes;

namespace WebApplication11.Modules
{
    public interface IModuleCollection : IList<ModuleEntry>
    {
        IModuleCollection ImportFromFolder(string folderPath);
    }

    [Component]
    public class ModuleCollection : List<ModuleEntry>, IModuleCollection
    {
        [Dependency]
        public ModuleLoader ModuleLoader { get; set; }

        public IModuleCollection ImportFromFolder(string folderPath)
        {
            AddRange(ModuleLoader.Load(folderPath));

            return this;
        }
    }
}
