using System.Linq;
using System;
namespace QwixxLib
{
    public class Player{

        public string name{get;set;}

        public GameForm gameForm {get;set;}

        public Player(string name)
        {
            this.name = name;
            gameForm = new GameForm();
        }


        //Player GetPoints and Wrong Rolls!!

        public short GetPoints(){
            short points = 0;

            foreach(byte[] srow in this.gameForm.rows)
            {
                points += Convert.ToInt16((srow.Where(e => e != 0).Count() - 1) * 0.5 + 1);
            }
            return points;
        }

        public bool PlayerIsActiv {get => this.gameForm.wrongRolss == 5 ? false : true;}
    }
}