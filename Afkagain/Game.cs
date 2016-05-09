using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using System.Drawing;

namespace Afkagain
{
    internal class Game : GameWindow
    {
        public static Renderer renderer;
        protected GameLogic game;
        public static Size size;
        public Game() : base(1280, 720)
        {
            size = Size;
            Resize += Game_Resize;
            RenderFrame += Game_RenderFrame;
            UpdateFrame += Game_UpdateFrame;
            renderer = new Renderer(SwapBuffers);
            game = new GameLogic();
            game.Start();
            renderer.Start();
        }

        private void Game_UpdateFrame(object sender, FrameEventArgs e)
        {
            game.Update((float)e.Time);
        }

        private void Game_RenderFrame(object sender, FrameEventArgs e)
        {
            renderer.Render((float)e.Time);
        }

        private void Game_Resize(object sender, EventArgs e)
        {
            Size = new Size(1280, 720);
            
        }
    }
}
