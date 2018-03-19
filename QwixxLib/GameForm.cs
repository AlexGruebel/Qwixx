using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace QwixxLib
{
    //20180319 Create Unit test for this
    public class GameForm
    {
        private byte _wrongRolss;
        public byte wrongRolss { get { return this.wrongRolss; }}
        
        private static bool[] activRows = { true, true, true, true };

        private byte[][] _rows;

        public byte this[int index1, int index2]
        {
            get{
                return _rows[index1][index2];
            }
            set {
                if(activRows[index1] && _rows[index1].Max() < index2)
                {
                    _rows[index1][index2] = value;
                    _rows[index1].Where(e => e - 1 < index2 && e == 0).Select(e => -1);
                }
                else
                {
                    throw new Exception();
                }
            }
        }

        public short GetPoints()
        {
            short points = 0;

            foreach(byte[] srow in _rows)
            {
                //points += (((short)srow.Count()) - 1) * 0.5) + 1;
                points += Convert.ToInt16((srow.Count() - 1) * 0.5 + 1);
            }

            return points;
        }

        public void WrongRoll()
        {
            _wrongRolss++;
        }
        
    }
}
