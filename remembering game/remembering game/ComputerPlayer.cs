using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace remembering_game
{
    internal class ComputerPlayer : BasicPlayer
    {
        #region fields
        public override string Name { get; } = "computer";
        public List<BasicCard> Optionalcard { get; set; } = new List<BasicCard>();
        #endregion

        #region methods
        public override int ChooseCard()
        {
            BasicCard c = null;
            Random random = new Random();
            //מחיקת הכרטיסים שנמצא להם זוג
            for (int i = 0; i < Optionalcard.Count(); i++)
            {
                if (Optionalcard[i].Discovered == true)
                {
                    Optionalcard.RemoveAt(i);
                    i--;
                }
            }
            //בדיקה האם אתה כרטיס שני -נשמור את הראשון
            for (int i = 0; i < Optionalcard.Count(); i++)
            {
                if (Optionalcard[i].First == true)
                {
                    c = Optionalcard[i];
                    break;
                }
            }

            if (c == null)//אם אתה כרטיס ראשון
            {
                //נבחר כרטיס שנפתח אי פעם ןגם יש לו זוג שנפתח אי פעם
                for (int i = 0; i < Optionalcard.Count(); i++)
                {
                    if (Optionalcard[i].IsOpened)
                    {
                        for (int j = 0; j < Optionalcard.Count(); j++)
                        {
                            if (Optionalcard[j].IsOpened == true && Optionalcard[i].Equals(Optionalcard[j]))
                                return Optionalcard[i].NumCard;
                        }
                    }
                }
                //שלא נפתח אף פעם -(אולי נמצא לו זוג) בחירת כרטיס 
                int num = random.Next(0, Optionalcard.Count());
                while (Optionalcard[num].IsOpened)
                    num = random.Next(0, Optionalcard.Count());
                return Optionalcard[num].NumCard;
            }
            else//אם אתה כרטיס שני
            {
                //מקרה בו יש לו זןג שנפתח אי פעם
                foreach (var p in Optionalcard)
                {
                    if (p.Equals(c) && p.IsOpened == true)
                        return p.NumCard;
                }
                //ננסה כרטיס חדש נפתח  פעם 
                int num = random.Next(0, Optionalcard.Count());
                while (!Optionalcard[num].IsOpened)
                    num = random.Next(0, Optionalcard.Count());
                return Optionalcard[num].NumCard;


            }


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
