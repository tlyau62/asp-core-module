using Microsoft.AspNetCore.Mvc.ApplicationParts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unity;
using UnityAddon.Core.Attributes;
using UnityAddon.Core.Context;

namespace WebApplication11.Modules
{
    [Component]
    public class ModuleRegistry : IAppCtxFinishPhase
    {
        [Dependency]
        public ApplicationPartManager PartManager { get; set; }

        [Dependency]
        public IModuleCollection ModuleCollection { get; set; }

        public void Process()
        {
            foreach (var entry in ModuleCollection)
            {
                PartManager.ApplicationParts.Add(new AssemblyPart(entry.Assembly));
            }
        }
    }
}
