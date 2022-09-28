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
    public class FlaxTexture
    {
        public GPUTexture tex;

        public int Width => tex.Width;
        public int Height => tex.Height;

        public void Disposes()
        {
            FlaxEngine.Object.Destroy(tex);
        }
        public FlaxTexture(GPUTexture gPUTexture)
        {
            tex = gPUTexture;
        }

        internal void SetSize(int width, int height)
        {
            tex.Resize(width, height);
        }
    }

    public class FlaxRTexture : IRTexture2D
    {
        public static GPUTexture Wight
        {
            get
            {
                var data = new GPUTextureDescription { Width = 2, Height = 2,Format = PixelFormat.R8G8B8A8_UNorm_sRGB,DefaultClearColor = Color.White,ArraySize=1, MipLevels=1, Depth = 1 };
                var tex = new GPUTexture();
                tex.Init(ref data);
                //tex.SetPixels(new Color[4] { Color.White, Color.White, Color.White, Color.White });
                return tex;
            }

        }

        public RTexture2D White => new RTexture2D(new FlaxTexture(Wight));

        public void Dispose(object tex)
        {
            ((FlaxTexture)tex).Disposes();
        }

        public int GetHeight(object target)
        {
            return ((FlaxTexture)target).Height;
        }

        public int GetWidth(object target)
        {
            return ((FlaxTexture)target).Width;
        }

        public object Make(TexType dynamice, TexFormat rgba32Linear)
        {
            PixelFormat pixelFormat = PixelFormat.Unknown;
            switch (rgba32Linear)
            {
                case TexFormat.Rgba32:
                    pixelFormat = PixelFormat.R8G8B8A8_UNorm_sRGB;
                    break;
                case TexFormat.Rgba32Linear:
                    pixelFormat = PixelFormat.R8G8B8A8_UNorm;
                    break;
                case TexFormat.Bgra32:
                    pixelFormat = PixelFormat.B8G8R8A8_UNorm_sRGB;
                    break;
                case TexFormat.Bgra32Linear:
                    pixelFormat = PixelFormat.B8G8R8A8_UNorm;
                    break;
                case TexFormat.Rg11b10:
                    pixelFormat = PixelFormat.R11G11B10_Float;
                    break;
                case TexFormat.Rgb10a2:
                    pixelFormat = PixelFormat.R10G10B10A2_UNorm;
                    break;
                case TexFormat.Rgba64:
                    pixelFormat = PixelFormat.R16G16B16A16_UNorm;
                    break;
                case TexFormat.R8:
                    pixelFormat = PixelFormat.R8_UNorm;
                    break;
                case TexFormat.R16:
                    pixelFormat = PixelFormat.R16_UNorm;
                    break;
                case TexFormat.DepthStencil:
                    pixelFormat = PixelFormat.R16_UNorm;
                    break;
                case TexFormat.Depth16:
                    pixelFormat = PixelFormat.R16_UNorm;
                    break;
                default:
                    break;
            }
            var data = new GPUTexture();
            var initData = new GPUTextureDescription { Height = 2, Width = 2, Format = pixelFormat, ArraySize = 1, MipLevels = 1, Depth = 1 };
            data.Init(ref initData);
            return new FlaxTexture(data);
        }

        public object MakeFromColors(Colorb[] colors, int width, int height, bool srgb)
        {
            var data = new GPUTextureDescription { Width = width, Height = height, Format = (srgb) ? PixelFormat.R8G8B8A8_UNorm_sRGB : PixelFormat.R8G8B8A8_UNorm, ArraySize = 1, MipLevels = 1,Depth = 1 };
            var tex = new GPUTexture();
            tex.Init(ref data);
            var colore = new Color32[colors.Length];
            for (int i = 0; i < colors.Length; i++)
            {
                colore[i] = new Color32(colors[i].r, colors[i].g, colors[i].b, colors[i].a);
            }
            //tex.SetPixels(colore);
            return new FlaxTexture(tex);
        }

        public void SetAddressMode(object target, TexAddress value)
        {
        }

        public void SetAnisoptropy(object target, int value)
        {
        }

        public void SetColors(object tex, int width, int height, byte[] rgbaData)
        {
            var colore = new Color32[rgbaData.Length / 4];
            for (int i = 0; i < rgbaData.Length; i += 4)
            {
                colore[i/4] = new Color32(rgbaData[i], rgbaData[i + 1], rgbaData[i + 2], rgbaData[i + 3]);
            }
            //((FlaxTexture)tex).tex.SetPixels(colore);
        }

        public void SetColors(object tex, int width, int height, Colorb[] rgbaData)
        {
            var colore = new Color32[rgbaData.Length];
            for (int i = 0; i < rgbaData.Length; i++)
            {
                colore[i] = new Color32(rgbaData[i].r, rgbaData[i].g, rgbaData[i].b, rgbaData[i].a);
            }
            //((FlaxTexture)tex).tex.SetPixels(colore);
        }

        public void SetSampleMode(object target, TexSample value)
        {
        }

        public void SetSize(object tex, int width, int height)
        {
            ((FlaxTexture)tex).SetSize(width, height);
        }
    }
}
