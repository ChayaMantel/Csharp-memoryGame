using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace remembering_game
{
    internal class SimbolCard:BasicCard
    {
        public char Simbol { get; set; }
        public ConsoleColor Color { get; set; } = ConsoleColor.Magenta;
       
        public override void Drawing()
        {
            Console.BackgroundColor=ConsoleColor.White;
            for (int i = Position.Y-1; i <= Position.Y+1; i++)
            {
                for (int j = Position.X-2; j <= Position.X + 2; j++)
                {
                    Console.SetCursorPosition(j, i);
                    Console.WriteLine(" ");
                }
            }
            Console.ForegroundColor = (ConsoleColor)Color;
            Console.SetCursorPosition(Position.X, Position.Y);
               Console.WriteLine(Simbol);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        public override bool Equals(object? obj)
        {
            return (obj as SimbolCard).Simbol == Simbol && (obj as BasicCard).NumCard != NumCard; ;
        }

        
    }
}
