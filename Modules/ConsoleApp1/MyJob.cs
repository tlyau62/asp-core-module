using System;
using System.Collections.Generic;
using System.Text;
using Unity;
using UnityAddon.Core.Attributes;
using Serilog;

namespace ConsoleApp1
{
    [Component]
    public class MyJob
    {
        private ILogger _logger = Log.ForContext<MyJob>();

        [PostConstruct]
        public void Init()
        {
            _logger.Debug("a = 10");
        }
    }
}
