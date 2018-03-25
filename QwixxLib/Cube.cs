using System;

namespace QwixxLib
{
    public class Cube
    {
        public string color{ get; set; }
        public byte id { get; set; }

        private byte _RandomCubeNr;
        private static Random rnd = new Random(DateTime.Now.Millisecond);

        public void GenerateRndCubeNr(){
            this._RandomCubeNr = ((byte)rnd.Next(1, 7));
        }

        public  byte RandomCubeNr { get
            {
                return _RandomCubeNr;
            }
        }
    }
}