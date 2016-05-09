using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afkagain
{
    class Mathe
    {
        public static float lerp(float v0, float v1, float t)
        {
            return (1 - t) * v0 + t * v1;
        }
        public static Vector3 lerp(Vector3 v0, Vector3 v1, float t)
        {
            return new Vector3(lerp(v0.X, v1.X, t), lerp(v0.Y, v1.Y, t), lerp(v0.Z, v1.Z, t));
        }
    }
}
