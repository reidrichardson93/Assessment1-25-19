using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment4
{
    class Point
    {
        //AUTO PROPERTY
            public double x {get; set;}
            public double y { get; set; }

            static Random rnd = new Random();
        
        //Constructor
            public Point (double start_x = 0, double start_y = 0){
            x = start_x;
            y = start_y;
            }
        
        /*public void Draw() {
            int color = rnd.Next(0,8);
            switch (color)
            {
                case 0: {Console.ForegroundColor = ConsoleColor.White; break;}
                case 1: {Console.ForegroundColor = ConsoleColor.Blue; break;}
                case 2: {Console.ForegroundColor = ConsoleColor.Green; break;}
                case 3: {Console.ForegroundColor = ConsoleColor.Red; break;}
                case 4: {Console.ForegroundColor = ConsoleColor.Yellow; break;}
                case 5: {Console.ForegroundColor = ConsoleColor.Magenta; break;}
                case 6: {Console.ForegroundColor = ConsoleColor.Gray; break;}
                case 7: {Console.ForegroundColor = ConsoleColor.Cyan; break;}
                default:
                    break;
            }
            Console.SetCursorPosition((int)x,(int)y);
            Console.Write("+");
        }*/

    }
}
