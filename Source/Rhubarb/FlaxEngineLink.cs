using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RhuEngine.Linker;
using RhuEngine;
using RhuEngine.Managers;
using Rhubarb.FlaxLinking;
using RhuSettings;
using RhuEngine.Settings;

namespace Rhubarb
{
    public class FlaxRenderSettings : RenderSettingsBase
    {

    }

    public class FlaxEngineLink : IEngineLink
    {

        public EngineRunner engineRunner;

        public FlaxEngineLink(EngineRunner _engineRunner)
        {
            engineRunner = _engineRunner;
        }

        public SupportedFancyFeatures SupportedFeatures => SupportedFancyFeatures.Basic;

        public bool ForceLibLoad => true;

        public bool SpawnPlayer => true;

        public bool CanRender => true;

        public bool CanAudio => false;

        public bool CanInput => false;

        public string BackendID => "Flax Engine";

        public bool InVR => false;

        public bool LiveVRChange => false;

        public Type RenderSettingsType => typeof(FlaxRenderSettings);

        public event Action<bool> VRChange;

        Engine Engine;

        public void BindEngine(Engine engine)
        {
            Engine = engine;
        }
        public void ChangeVR(bool value)
        {

        }

        public void LoadArgs()
        {
            if (Engine._forceFlatscreen)
            {
            }
            else
            {
            }
        }

        public void LoadInput(InputManager manager)
        {
        }

        public void LoadStatics()
        {
            RTexture2D.Instance = new FlaxRTexture();
            RRenderer.Instance = new FlaxRRender();
            RTime.Instance = new FlaxRTime();
            new RBullet.BulletPhsyicsLink(true).RegisterPhysics();
        }

        public void Start()
        {
        }
    }
}
