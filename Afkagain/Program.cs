using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Afkagain
{
    static class Program
    {
        static void Main()
        {
            Game game = new Game();
            game.Run(60);
        }
    }
}
