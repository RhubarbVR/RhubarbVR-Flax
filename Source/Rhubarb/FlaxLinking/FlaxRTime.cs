using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RhuEngine.Linker;
using RhuEngine;
using RhuEngine.Managers;
using FlaxEngine;

namespace Rhubarb.FlaxLinking
{
    public class FlaxRTime : IRTime
    {
        public float Elapsedf => Time.DeltaTime;
    }
}
