using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace remembering_game
{
    internal class UserPlayer : BasicPlayer
    {
        #region fields
          public override string Name { get; }
        #endregion

        #region constractor
          public UserPlayer()
          {

          }

        public UserPlayer(string name)
         {
            Name = name;
         }
        #endregion

        #region methods
        public override int ChooseCard()
        {
            Console.SetCursorPosition(0, 1);
            Console.WriteLine("                                                      ");
            Console.WriteLine("   ");
            Console.SetCursorPosition(0, 1);
            Console.WriteLine("enter the card you choose");
            return int.Parse(Console.ReadLine());
        }

        public override void ShowingCards()
        {
            for (int i = 0; i < Cards.Count(); i++)
            {
                Cards[i].Drawing();
            }
        }
        #endregion



    }
}
