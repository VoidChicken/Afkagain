using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afkagain
{
    class Renderer
    {
        public Action swapBuffers;
        public Renderer(Action bufferSwap)
        {
            swapBuffers = bufferSwap;
        }
        public void Start()
        {
            GL.Viewport(0, 0, 1280, 720);
            
        }
        public void UpdateSky()
        {
            float l = Sky.perc;
            Vector3 day = new Vector3(135f/255f, 206f/255f, 235f/255f);
            Vector3 night = new Vector3(0, .05f, .1f);
            Vector3 skyColor = Mathe.lerp(day, night, l);
            GL.ClearColor(skyColor.X, skyColor.Y, skyColor.Z, 1);
        }
        public void Render(float delta)
        {
            UpdateSky();
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            swapBuffers();
        }
    }
}
