using System.Collections.Generic;
using System.Linq;

namespace PacmanWinForms
{
    public static class HighScoreList
    {
        public static List<HighScores> hsList = new List<HighScores>();

        public static void add(HighScores item)
        {
            int min =(hsList.Count>0) ? hsList.Min(r => r.score) : 0;
            if(item.score > min || hsList.Count < 10)
            {
                if (hsList.Count > 9) hsList.RemoveAt(hsList.Count - 1);
                hsList.Add(item);
            }
            hsList = hsList.OrderByDescending(p => p.score).ToList();
        }

        public static int min()
        {
            if (hsList.Count > 0) return hsList.Min(r => r.score);
            else return 0;
        }

        public static int max()
        {
            if (hsList.Count > 0) return hsList.Max(r => r.score);
            else return 0;
        }

        public static void remove(HighScores item)
        {
            for(int i = 0; i < hsList.Count; i++)
            {
                if(hsList[i] == item) { hsList.RemoveAt(i);break; }
            }
        }
    }

}
