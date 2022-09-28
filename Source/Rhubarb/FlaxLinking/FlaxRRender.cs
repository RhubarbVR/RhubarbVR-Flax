using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RhuEngine.Linker;
using RhuEngine;
using RhuEngine.Managers;
using FlaxEngine;
using RNumerics;
using static System.Net.Mime.MediaTypeNames;
using static RNumerics.Colorf;

namespace Rhubarb.FlaxLinking
{

    public class FlaxRRender : IRRenderer
    {
        public float MinClip { get; set; }
        public float FarClip { get; set; }

        public RNumerics.Matrix GetCameraRootMatrix()
        {
            return new RNumerics.Matrix();
        }

        public bool GetEnableSky()
        {
            return false;
        }

        public void SetCameraRootMatrix(RNumerics.Matrix m)
        {
        }

        public void SetEnableSky(bool e)
        {
        }
    }
}
