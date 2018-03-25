using System;
using static System.Console;
using System.Collections.Generic;
using QwixxLib;
using System.Linq;
using System.Text;

namespace QwixxConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Welcome to Qwixx");
            while(true){
                Write("Do you want to play a round (y/n) ");
                if(ReadKey().Key == ConsoleKey.Y){
                    bool selectPlayer = true;
                    List<Player> players = new List<Player>();
                    Clear();
                    //Begin: select Players:
                    WriteLine("Now select your players: ");

                    byte i = 1;
                    do{ 
                        Write($"Name of player {i++}: ");
                        players.Add(new Player(Console.ReadLine()));
                        if(players.Count >= 2){
                            Write("Do you want to select more players (y/n): ");
                            if(ReadKey().Key != ConsoleKey.Y)
                            {
                                selectPlayer = false;
                            }
                            WriteLine();
                        }

                    }while(selectPlayer);
                    //End: select Players:
                    Clear();
                    //Begin Game
                    
                    //Cubes
                    Cube[] cubes = {
                        new Cube(){
                            color="white",
                            id=0
                        },
                        new Cube(){
                            color="white",
                            id=1
                        },
                        new Cube(){
                            color="blue",
                            id=2
                        },
                        new Cube(){
                            color="red",
                            id=3
                        },
                        new Cube(){
                            color="green",
                            id=4
                        },
                        new Cube(){
                            color="yellow",
                            id=5
                        }
                    };

                    do{
                        //Loop throughs players
                        foreach(var playerf1 in players)
                        {
                            WriteLine($"{playerf1.name} press any key roll the cubes!");
                            ReadKey();
                            //roll cubes

                            StringBuilder builder = new StringBuilder();

                            foreach(var cube in cubes)
                            {
                                cube.GenerateRndCubeNr();
                                builder.Append(cube.color);
                                builder.Append(": ");
                                builder.Append(cube.RandomCubeNr);
                                builder.Append(" ");
                            }
                            string cubeRolls = builder.ToString();
                            Clear();
                            WriteLine(cubeRolls);
                            WriteLine($"{playerf1.name} put one color to the gamefield");
                            PrintGameForm(playerf1.gameForm);
                            ReadKey();
                            Clear();
                            foreach(var playerf2 in players.Where(p => p != playerf1)){
                                WriteLine(cubeRolls);
                                PrintGameForm(playerf2.gameForm);
                                WriteLine($"{playerf2.name} put one the sum of the white values to your gamefield (name the color of the row): ");
                                sbyte index;
                                string color;
                                do{
                                color = ReadLine();
                                index = playerf2.gameForm.GetIdForColor(color);
                                if(index == -1){
                                    WriteLine("this is not a valid color! Try again!");
                                }
                                }while(index == -1);
                                WriteLine(index);

                                if(!playerf2.gameForm.AddMarcAt((byte)index, (byte)cubes.Where(e => e.color.Equals(color)).Sum(c => c.RandomCubeNr)))
                                {
                                    WriteLine("you cant put the color on this field!");
                                    playerf2.gameForm.WrongRoll();
                                }

                                Clear();

                            }
                            Clear();
                        }
                    }while(!players.Exists(p => p.PlayerIsActiv == false));
                }else{
                        break;
                }

            }
        }

        static void PrintGameForm(GameForm form){
            for(byte x = 0; x<form.rows.Length;x++)
            {

                WriteLine("----------------------------------------------");
                Write($"{form.GetColor(x), -7}");
                if(form.checkAsc[x])
                {
                    for(byte i = 0; i<form.rows[x].Length;i++)
                    {
                        Write($"|{(form.rows[x][i] == (byte) 0 ? Convert.ToString(12 - i) : "x")}|");
                    }
                }else
                {
                    
                    for(byte i = 0; i<form.rows[x].Length;i++)
                    {
                        Write($"|{(form.rows[x][i] == (byte) 0 ? Convert.ToString(1 + i) : "x")}|");
                    }
                }
                WriteLine();
            }
            WriteLine("----------------------------------------------");
        }
    }
}
