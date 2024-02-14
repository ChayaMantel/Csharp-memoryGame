using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace remembering_game
{
    internal class LetterCard:BasicCard
    {
        public char Letter { get; set; }

        public override void Drawing()
        {
            Console.BackgroundColor = ConsoleColor.White;
            for (int i = Position.Y - 1; i <= Position.Y + 1; i++)
            {
                for (int j = Position.X - 2; j <= Position.X + 2; j++)
                {
                    Console.SetCursorPosition(j, i);
                    Console.WriteLine(" ");
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.WriteLine(Letter);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        public override bool Equals(object? obj)
        {
            return (obj as LetterCard ).Letter==Letter && (obj as BasicCard).NumCard != NumCard;   
        }

    }
}
