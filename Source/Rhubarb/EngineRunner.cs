using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using FlaxEngine;
using Rhubarb.FlaxLinking;
using RhuEngine;
using RhuEngine.Linker;
using REngine = RhuEngine.Engine;

namespace Rhubarb
{
    /// <summary>
    /// EngineRunner Script.
    /// </summary>
    public class EngineRunner : Script
    {

        public Camera Camera { get; set; }

        [ThreadStatic]
        [HideInEditor]
        public bool IsMainThread = false;

        public static EngineRunner _;

        [HideInEditor]
        public OutputCapture outputCapture;

        [HideInEditor]
        public FlaxEngineLink link;

        [HideInEditor]
        public REngine engine;

        public bool StartInVR = false;

        /// <inheritdoc/>
        public override void OnStart()
        {
            if (RLog.Instance == null)
            {
                RLog.Instance = new FlaxRlog();
            }
            else
            {
                ((FlaxRlog)RLog.Instance).Clear();
            }
            if (engine != null)
            {
                RLog.Err("Engine already running");
                return;
            }

            if (!IsMainThread)
            {
                if (Thread.CurrentThread.Name != "Flax Main Thread")
                {
                    Thread.CurrentThread.Name = "Flax Main Thread";
                }
                Thread.CurrentThread.Priority = System.Threading.ThreadPriority.Highest;
                IsMainThread = true;
                _ = this;
            }
            var platform = Platform.PlatformType;
            if(platform == PlatformType.Android)
            {
                RLog.Info("Is on Android");
            }
            outputCapture = new OutputCapture();
            link = new FlaxEngineLink(this);
            var args = new List<string>(Environment.GetCommandLineArgs());
            if (!StartInVR)
            {
                args.Add("--no-vr");
            }
            var appPath = Environment.CurrentDirectory;
            RLog.Info("App Path: " + appPath);
            engine = new REngine(link, args.ToArray(), outputCapture, appPath);
            engine.OnCloseEngine += () =>
            {
#if FLAX_EDITOR
                FlaxEditor.Editor.Instance.Simulation.RequestStopPlay();
#endif 
                ProcessCleanup();
            };
            engine.Init();
        }
        private bool IsDisposeing { set; get; }

        private void ProcessCleanup()
        {
            if(engine == null)
            {
                RLog.Err("Engine not started for cleanup");
                return;
            }
            try
            {
                if (!IsDisposeing)
                {
                    IsDisposeing = true;
                    RLog.Info("Rhubarb CleanUp Started");
                    engine.IsCloseing = true;
                    engine.Dispose();
                    engine = null;
                    REngine.MainEngine = null; 
                }
            }
            catch(Exception ex)
            {
                RLog.Err("Failed to start Rhubarb CleanUp " + ex.ToString());
            }
        }


        /// <inheritdoc/>
        public override void OnUpdate()
        {
            engine?.Step();
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            RLog.Info("Destroy called");
            ProcessCleanup();
        }
    }
}
