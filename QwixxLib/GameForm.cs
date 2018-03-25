using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace QwixxLib
{
    public class GameForm
    {
        private byte _wrongRolss;
        public byte wrongRolss { get { return this._wrongRolss; }}
        
        private bool[] _checkAsc = {true, false, true, false};

        private static bool[] activRows = { true, true, true, true };

        private byte[][] _rows;

        public GameForm(){
            _rows = new byte[4][];
            _rows[0] = new byte[12];
            _rows[1] = new byte[12];
            _rows[2] = new byte[12];
            _rows[3] = new byte[12];
        }
        
        public byte[][] rows {get{return this._rows;}}

        public bool[] checkAsc {get => this._checkAsc;}
        private string[] _colors = {"green", "blue", "red", "yellow"};

        public bool AddMarcAt(byte index1, byte value){
            byte index2 = Convert.ToByte(value -1);
            if(CheckMarc(_rows[index1], value, _checkAsc[index1]) && activRows[index1])
            {
                _rows[index1][index2] = value;
                return true;
            }else{
                return false;
            }
        }

        public string GetColor(byte index)
        {
            return _colors[index];
        }

        //returns -1 if the color is not found
        public sbyte GetIdForColor(string color)
        {
            sbyte index = -1;
            for(sbyte i = 0; i<_colors.Length;i++)
            {
                if(_colors[i].Equals(color))
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        public void WrongRoll()
        {
            _wrongRolss++;
        }

        private bool CheckMarc(byte[] row, byte value, bool checkAsc){
            if(checkAsc){
                if(row.Min() > value){
                    return true;
                }else{
                    return false;
                }
            }else{
                if(row.Max() < value){
                    return true;
                }else{
                    return false;
                }
            }
        }
    }
}
