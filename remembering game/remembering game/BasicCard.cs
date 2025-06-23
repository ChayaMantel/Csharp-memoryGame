using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace remembering_game
{


    abstract class BasicCard
    {
        #region fields
        public bool IsOpened { get; set; } = false;
        public bool First { get; set; } = false;
        public bool Discovered { get; set; } = false;
        public Point Position { get; set; }
        public int NumCard { get; set; }

        #endregion

        #region methods        
        public override abstract bool Equals(object? obj);

        public abstract void Drawing();

        public void DrawingBlack()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            for (int i = Position.Y - 1; i <= Position.Y + 1; i++)
            {
                for (int j = Position.X - 2; j <= Position.X + 2; j++)
                {
                    Console.SetCursorPosition(j, i);
                    Console.WriteLine(" ");
                }
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void DrawingOposite()
        {
            Console.BackgroundColor = ConsoleColor.Green;
            for (int i = Position.Y - 1; i <= Position.Y + 1; i++)
            {
                for (int j = Position.X - 2; j <= Position.X + 2; j++)
                {
                    Console.SetCursorPosition(j, i);
                    Console.WriteLine(" ");
                }
            }
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.WriteLine(NumCard);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        #endregion

    }
}
