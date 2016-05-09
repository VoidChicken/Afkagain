using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afkagain
{
    class Sky
    {
        public static float time = 0;
        internal static float perc
        {
            get
            {
                return time / 600;
            }
        }
    }
}
