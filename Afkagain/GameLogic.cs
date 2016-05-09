using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afkagain
{
    internal class GameLogic
    {
        float time;
        public GameLogic()
        {

        }
        public void Start()
        {

        }
        bool d = false;
        public void Update(float delta)
        {
            if ((int)time == 0) d = false;
            if (time <= 600 && !d)
            {
                time = (time + delta);
            } else if (time > 600)
            {
                d = true;
                time = 600;
            } else if (d)
            {
                
                time = (time - delta);
            }
            Sky.time = time;
            Console.WriteLine(Sky.time);
        }
    }
}
