using System;
using System.Collections.Generic;
using FlaxEngine;
using RhuEngine;
using REngine = RhuEngine.Engine;

namespace Rhubarb
{
    /// <summary>
    /// EngineRunner Script.
    /// </summary>
    public class EngineRunner : Script
    {

        public Camera Camera { get; set; }

        /// <inheritdoc/>
        public override void OnStart()
        {
            RhubarbNativeFunctions.RunNativeAction(new Vector4(1, 1, 1, 1));
            // Here you can add code that needs to be called when script is created, just before the first game update
        }

        /// <inheritdoc/>
        public override void OnUpdate()
        {
            // Here you can add code that needs to be called every frame
        }
    }
}
