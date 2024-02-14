using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace remembering_game
{
    internal class MathAritmetic:BasicCard
    {
        #region fields
        public string MathAritmeticEx { get; set; }
        public int Solution { get; set; }

        #endregion

        #region methods
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
            Console.SetCursorPosition(Position.X - 1, Position.Y);
            Console.WriteLine(MathAritmeticEx);
            Console.BackgroundColor = ConsoleColor.Black;
        }


        public override bool Equals(object? obj)
        {
            return (obj as MathAritmetic).Solution == Solution && (obj as BasicCard).NumCard != NumCard; ;
        }

        #endregion

    }
}
