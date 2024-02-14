using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace remembering_game
{
    abstract class BasicPlayer
    {
        #region fields
        public int Score { get; set; }
        public List <BasicCard>Cards { get; set; }   = new List<BasicCard>();
        public abstract string Name { get; }

        #endregion

        #region methods

        public abstract int ChooseCard();

        public abstract void ShowingCards();
        
        #endregion

    }
}
