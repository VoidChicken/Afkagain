using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpNoisePCL.Noise;
using SharpNoisePCL;
namespace Afkagain
{
    internal class Block
    {
        public int blockType = 0;
    }
    internal class Chunk
    {
        Block[,,] m_Array;
        public Chunk ()
        {
            m_Array = new Block[16, 16, 16];
        }
        public void Generate(PerlinNoise noise, int seed)
        {
            for (int x = 0; x < 16; x++)
            {
                for (int y = 0; y < 16; y++)
                {
                    int height = (int)noise.Get2D(x/ 10 + seed, y/10+ seed) *50;
                    for (int z = 0; z < height; z++)
                    {
                        m_Array[x, z, y] = new Block();
                    }
                }
            }
            
        }
    }
    internal class World
    {
        public World()
        {
            PerlinNoise p = new PerlinNoise();
            
        }
    }
}
