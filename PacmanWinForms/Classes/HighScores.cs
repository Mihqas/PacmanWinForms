using System.Text;
using System.Threading.Tasks;

namespace PacmanWinForms
{
    public class HighScores
    {
        public int score { get; set; }
        public string Name { get; set; }
        public int coinsAdded { get; set; }
        public Difficulty difficulty { get; set; }
        public HighScores(string Name , int score, int coinsAdded, Difficulty dif)
        {
            this.coinsAdded = coinsAdded;
            difficulty = dif;
            this.Name = Name;
            this.score = score;
        }
    }

}
