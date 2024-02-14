using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace remembering_game
{
    internal class Board
    {
        public BasicCard[] cards { get; set; } =new BasicCard[20];
       //גודל של משחק מוכן, ניתן לשנות ולהחליט לפי רמת משחק
        private Point[] Points = new Point[20]
       {
         new Point {X=42, Y=6 } , new Point {X=50,Y=6 } , new Point { X=58,Y=6} ,new Point {X=66, Y=6 } , new Point {X=74,Y=6 } ,
         new Point {X=42,Y=11 } ,new Point {X=50, Y=11 } , new Point {X=58,Y=11 } , new Point {X=66, Y=11 } ,new Point {X=74,Y=11 } ,
         new Point { X=42,Y=16} , new Point { X=50, Y=16} ,new Point {X=58,Y=16 } , new Point {X=66, Y=16 } , new Point {X=74,Y=16 } ,
         new Point {X=42, Y=21 } , new Point {X=50, Y=21 } , new Point { X=58,Y=21} ,new Point {X=66, Y=21} , new Point {X=74,Y=21 }
       };
        public Board()
        {

        }

        public Board(BasicCard[] cards)
        {
            this.cards = cards;
        }
        
        public void Restart()
        {
            Console.Clear();    
            DrawingBoard();
            Random random = new Random();
            int[] arr = new int[20]; 
            int[] count = new int[20];
            int r = 0;
            for (int i = 0; i < cards.Length; i++)
            {
                do
                    r = random.Next(20);
                while (count[r] == 1);
                arr[i] = r;
                count[r]++;

            }
            for (int i = 0; i < cards.Length; i++)
            {
               
                cards[i].Position = Points[arr[i]];
                cards[i].NumCard = arr[i]+1;

            }                    
            for (int i = 0; i < cards.Length; i++)
            {
                Console.ForegroundColor= ConsoleColor.Black; 
                Console.BackgroundColor= ConsoleColor.Green;
                Console.SetCursorPosition(cards[i].Position.X, cards[i].Position.Y);
                      Console.WriteLine(cards[i].NumCard); 
            }
           
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

        }
        public void DrawingBoard()
        {

          
            Console.BackgroundColor = ConsoleColor.Red;
            for (int i = 2; i <= 25; i++)
            {
                Console.SetCursorPosition(35, i);
                Console.WriteLine("  ");
            }
            for (int i = 2; i <= 25; i++)
            {

                Console.SetCursorPosition(80, i);
                Console.WriteLine("  ");

            }
            for (int i = 35; i < 80; i++)
            {

                Console.SetCursorPosition(i, 2);
                Console.WriteLine(" ");

            }
            for (int i = 35; i < 80; i++)
            {

                Console.SetCursorPosition(i, 25);
                Console.WriteLine(" ");

            }
            //ציור הקלפים
            for (int i = 40; i < 78; i += 8)
            {
                for (int j = 5; j < 25; j += 5)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(i, j);
                    Console.WriteLine("     ");
                    Console.SetCursorPosition(i, j + 1);
                    Console.WriteLine("     ");
                    Console.SetCursorPosition(i, j + 2);
                    Console.WriteLine("     ");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
            }
           
            Console.WriteLine(); for (int i = 40; i < 78; i += 8)
            {
                for (int j = 5; j < 25; j += 5)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(i, j);
                    Console.WriteLine("     ");
                    Console.SetCursorPosition(i, j + 1);
                    Console.WriteLine("     ");
                    Console.SetCursorPosition(i, j + 2);
                    Console.WriteLine("     ");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
            }
            
            Console.BackgroundColor = ConsoleColor.Black;
            
        }

        public bool IsValid(BasicCard card)
        {
            if (card.First == true || card.Discovered == true)      
                return false;
            return true;           
        }
        public bool IsExistCards()
        {
          
            for (int i = 0; i < cards.Length; i++)
            {
                if (!cards[i].Discovered)
                {
                    return true;
                }
            }
           
            return false;

        }

    }
}
