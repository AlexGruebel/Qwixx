using System;

namespace QwixxLib
{
    public struct Cube
    {
        public string color{ get; set; }
        public byte id { get; set; }
        public byte RandomCubeNr { get
            {
                return ((byte)new Random(DateTime.Now.Millisecond).Next(1, 7));
            }
        }
    }
}
