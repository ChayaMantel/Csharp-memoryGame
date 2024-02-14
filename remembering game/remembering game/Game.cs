using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml.Linq;

namespace remembering_game
{
    public enum ECard { Math = 1, Simbol = 2, Letter = 3 };
    internal class Game
    {
        #region fields
        public int NumOfPlayers { get; } = 4;
        public List<BasicPlayer> Players { get; set; } = new List<BasicPlayer>();
        public ECard ec { get; set; }
        public int IndexCurrentPlayer { get; set; }
        public Board b { get; set; }
        Dictionary<ECard, BasicCard[]> allGames = new Dictionary<ECard, BasicCard[]>();
        MathAritmetic[] mathAritmetics = new MathAritmetic[]{
                new MathAritmetic() { MathAritmeticEx = "5+2", Solution = 7 },
                new MathAritmetic() { MathAritmeticEx = "4+3", Solution = 7 },
                new MathAritmetic() { MathAritmeticEx = "5-3", Solution = 2 },
                new MathAritmetic() { MathAritmeticEx = "4-2", Solution = 2 },
                new MathAritmetic() { MathAritmeticEx = "2+1", Solution = 3 },
                new MathAritmetic() { MathAritmeticEx = "3*1", Solution = 3 },
                new MathAritmetic() { MathAritmeticEx = "2+7", Solution = 9 },
                new MathAritmetic() { MathAritmeticEx = "4+5", Solution = 9 },
                new MathAritmetic() { MathAritmeticEx = "1+3", Solution = 4 },
                new MathAritmetic() { MathAritmeticEx = "2*2", Solution = 4 },
                new MathAritmetic() { MathAritmeticEx = "2+3", Solution = 5 },
                new MathAritmetic() { MathAritmeticEx = "4+1", Solution = 5 },
                new MathAritmetic() { MathAritmeticEx = "3*2", Solution = 6 },
                new MathAritmetic() { MathAritmeticEx = "6*1", Solution = 6 },
                new MathAritmetic() { MathAritmeticEx = "6+2", Solution = 8 },
                new MathAritmetic() { MathAritmeticEx = "4*2", Solution = 8 },
                new MathAritmetic() { MathAritmeticEx = "6/6", Solution = 1 },
                new MathAritmetic() { MathAritmeticEx = "1+0", Solution = 1},
                new MathAritmetic() { MathAritmeticEx = "9*0", Solution = 0 },
                new MathAritmetic() { MathAritmeticEx = "0/5", Solution = 0 },

                };
        LetterCard[] letterCards = new LetterCard[]{
                new LetterCard() {  Letter='A' },
                new LetterCard() {  Letter='A' },
                new LetterCard() {  Letter='B' },
                new LetterCard() {  Letter='B' },
                new LetterCard() {  Letter='C' },
                new LetterCard() {  Letter='C' },
                new LetterCard() {  Letter='D' },
                new LetterCard() {  Letter='D' },
                new LetterCard() {  Letter='E' },
                new LetterCard() {  Letter='E' },
                new LetterCard() {  Letter='F' },
                new LetterCard() {  Letter='F' },
                new LetterCard() {  Letter='G' },
                new LetterCard() {  Letter='G' },
                new LetterCard() {  Letter='H' },
                new LetterCard() {  Letter='H' },
                new LetterCard() {  Letter='I' },
                new LetterCard() {  Letter='I' },
                new LetterCard() {  Letter='J' },
                new LetterCard() {  Letter='J' },
               };
        SimbolCard[] simbolCards = new SimbolCard[]{
                new SimbolCard() {  Simbol='#' ,Color=ConsoleColor.Red},
                new SimbolCard() {  Simbol='#' ,Color=ConsoleColor.Red },
                new SimbolCard() {  Simbol='$',Color=ConsoleColor.Blue },
                new SimbolCard() {  Simbol='$' ,Color=ConsoleColor.Blue},
                new SimbolCard() {  Simbol='@' ,Color=ConsoleColor.DarkYellow},
                new SimbolCard() {  Simbol='@',Color=ConsoleColor.DarkYellow },
                new SimbolCard() {  Simbol='*' ,Color=ConsoleColor.DarkGray},
                new SimbolCard() {  Simbol='*' ,Color=ConsoleColor.DarkGray},
                new SimbolCard() {  Simbol='&' ,Color=ConsoleColor.Cyan},
                new SimbolCard() {  Simbol='&' ,Color=ConsoleColor.Cyan},
                new SimbolCard() {  Simbol='~' , Color = ConsoleColor.Magenta},
                new SimbolCard() {  Simbol='~' , Color = ConsoleColor.Magenta},
                new SimbolCard() {  Simbol='!',  Color=ConsoleColor.DarkMagenta },
                new SimbolCard() {  Simbol='!' , Color = ConsoleColor.DarkMagenta},
                new SimbolCard() {  Simbol='?' , Color = ConsoleColor.Black},
                new SimbolCard() {  Simbol='?' , Color = ConsoleColor.Black},
                new SimbolCard() {  Simbol='%'  ,Color=ConsoleColor.Green },
                new SimbolCard() {  Simbol='%'  ,Color=ConsoleColor.Green},
                new SimbolCard() {  Simbol='+' ,Color=ConsoleColor.DarkRed},
                new SimbolCard() {  Simbol='+' ,Color=ConsoleColor.DarkRed},
               };

        #endregion

        #region constarctor
        public Game()
        {
            allGames.Add(ECard.Math, mathAritmetics);

            allGames.Add(ECard.Letter, letterCards);

            allGames.Add(ECard.Simbol, simbolCards);

        }
        #endregion

        #region methods


        public void Restart()
        {
            ComputerPlayer c = new ComputerPlayer();
            bool isComputer = false;
            string name;
            Console.WriteLine("enter 0 if you want to play against the computer and 1 if you want to play with friends");
            int choice;
            choice= int.Parse(Console.ReadLine());
            while(choice>1||choice<0)
            {
                Console.WriteLine("eror enter your choice again");
                choice = int.Parse(Console.ReadLine());
            }
            if (choice == 0)
            {
                Console.WriteLine("enter your name");
                name = Console.ReadLine();
                UserPlayer a = new UserPlayer(name);
                Players.Add(a);
                Players.Add(c);
                isComputer = true;
            }
            else
            {
                Console.WriteLine("enter the amount of players you want to play (more than 1)");
                int amount;
                amount= int.Parse(Console.ReadLine());
                while((amount>=4||amount<0))
                {
                    Console.WriteLine("eror enter your choice again");
                    choice = int.Parse(Console.ReadLine());
                }
                Console.WriteLine("enter your name");
                name = Console.ReadLine();
                UserPlayer a = new UserPlayer(name);
                Players.Add(a);
                amount--;
                if (amount > 0)
                {
                    Console.WriteLine("enter your name");
                    name = Console.ReadLine();
                    UserPlayer b = new UserPlayer(name);
                    Players.Add(b);
                    amount--;
                    if (amount > 0)
                    {
                        Console.WriteLine("enter your name");
                        name = Console.ReadLine();
                        UserPlayer d = new UserPlayer(name);
                        Players.Add(d);
                        amount--;
                        if (amount > 0)
                        {
                            Console.WriteLine("enter your name");
                            name = Console.ReadLine();
                            UserPlayer e = new UserPlayer(name);
                            Players.Add(e);
                            amount--;
                        }
                    }
                }
            }
            Console.WriteLine("enter the game you want to play\n" +
                "1: math\n" +
                "2: simbol\n" +
                "3: letters");
            int x = int.Parse(Console.ReadLine());
            //לברר!!!!!!
            switch (x)
            {
                case 1:
                    ec = ECard.Math;
                    break;
                case 2:
                    ec = ECard.Simbol;
                    break;
                case 3:
                    ec = ECard.Letter;
                    break;
            }
            if (isComputer)
            {
                for (int i = 0; i < allGames[ec].Length; i++)
                {
                    c.Optionalcard.Add(allGames[ec][i]);
                }
            }
            b = new Board(allGames[ec]);
            b.Restart();
            TheGame();
        }
        public void FindCouple(BasicCard c, BasicCard d)
        {
            //מחיקת הכרטיסים מהלוח
            for (int i = 0; i < 3; i++)
            {
                c.DrawingBlack();
                d.DrawingBlack();
                Thread.Sleep(400);
                c.Drawing();
                d.Drawing();
                Thread.Sleep(400);
            }
            c.DrawingBlack();
            d.DrawingBlack();
            c.Discovered = true;
            d.Discovered = true;
            //הוספה לכרטיסי שחקן
            Players[IndexCurrentPlayer].Cards.Add(c);
            Players[IndexCurrentPlayer].Cards.Add(d);
            //הוספת נקודות
            Players[IndexCurrentPlayer].Score += 10;
        }
        public void Winner()
        {
            Random random = new Random();
            Console.Clear();
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
            int max = Players.Max(p => p.Score);
            for (int i = 0; i < Players.Count(); i++)
            {
                if (Players[i].Score == max)
                {
                    Console.WriteLine($"the winner is:{Players[i].Name} with score {Players[i].Score}");
                    Players[i].ShowingCards();
                }
             
            }

            for (int i = 0; i < 10000000; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.ForegroundColor = (ConsoleColor)random.Next(15);
                Thread.Sleep(50);
                for (int j = 0; j < 4; j++)
                {
                    if (j == 0)
                    {
                        Console.SetCursorPosition(random.Next(120), random.Next(2));
                        Console.WriteLine("*");
                    }
                    else if (j == 1)
                    {
                        Console.SetCursorPosition(random.Next(120), random.Next(27, 29));
                        Console.WriteLine("*");
                    }
                    else if (j == 2)
                    {
                        Console.SetCursorPosition(random.Next(35), random.Next(29));
                        Console.WriteLine("*");
                    }
                    else
                    {
                        Console.SetCursorPosition(random.Next(85, 120), random.Next(29));
                        Console.WriteLine("*");
                    }

                }


            }

        }
        public void TheGame()
        {
            int num, index1 = -1, index2 = -1;
            bool flag;

            while (b.IsExistCards())
            {
                for (int i = 0; i < Players.Count(); i++)
                {
                    Thread.Sleep(1000);
                    flag = false;
                    IndexCurrentPlayer = i;
                    Console.SetCursorPosition(0, 0);
                    Console.Write($" {Players[i].Name}: first choice       ");
                    num = Players[i].ChooseCard();
                    while (num < 0 || num > 20)
                    {
                        Console.SetCursorPosition(0, 0);
                        Console.Write($" {Players[i].Name}: first choice again");
                        num = Players[i].ChooseCard();
                    }
                    while (!flag)
                    {
                        for (int j = 0; j < b.cards.Length; j++)
                        {
                            if (b.cards[j].NumCard == num)
                            {
                                if (b.IsValid(b.cards[j]))
                                {
                                    b.cards[j].Drawing();
                                    index1 = j;
                                    b.cards[j].IsOpened = true;
                                    b.cards[j].First = true;
                                    flag = true;

                                }
                                else
                                {
                                    Console.SetCursorPosition(0, 0);
                                    Console.Write($" {Players[i].Name}: first choice again");
                                    num = Players[i].ChooseCard();
                                    while (num < 0 || num > 20)
                                    {
                                        Console.SetCursorPosition(0, 0);
                                        Console.Write($" {Players[i].Name}: first choice again");
                                        num = Players[i].ChooseCard();
                                    }

                                }

                            }
                        }

                    }
                    flag = false;

                    Console.SetCursorPosition(0, 0);
                    Console.Write($" {Players[i].Name}: second choice       ");
                    num = Players[i].ChooseCard();
                    while (num < 0 || num > 20)
                    {
                        Console.SetCursorPosition(0, 0);
                        Console.Write($" {Players[i].Name}: second choice again ");
                        num = Players[i].ChooseCard();
                    }
                    while (!flag)
                    {
                        for (int j = 0; j < b.cards.Length; j++)
                        {
                            if (b.cards[j].NumCard == num)
                            {
                                if (b.IsValid(b.cards[j]))
                                {
                                    b.cards[j].Drawing();
                                    index2 = j;
                                    b.cards[j].IsOpened = true;
                                    flag = true;
                                }
                                else
                                {
                                    Console.SetCursorPosition(0, 0);
                                    Console.Write($" {Players[i].Name}: second  choice again ");
                                    num = Players[i].ChooseCard();
                                    while (num < 0 || num > 20)
                                    {
                                        Console.SetCursorPosition(0, 0);
                                        Console.Write($" {Players[i].Name}: second  choice again ");
                                        num = Players[i].ChooseCard();
                                    }
                                }
                            }
                        }
                    }

                    b.cards[index1].First = false;
                    if (b.cards[index1].Equals(b.cards[index2]))
                    {
                        FindCouple(b.cards[index1], b.cards[index2]);
                        if (!b.IsExistCards()) 
                        {
                            Winner();
                            break;
                        }
                          

                    }
                    else
                    {
                        Thread.Sleep(1500);
                        b.cards[index1].DrawingOposite();
                        b.cards[index2].DrawingOposite();
                    }
                }

            }
        }
        #endregion


    }
}
