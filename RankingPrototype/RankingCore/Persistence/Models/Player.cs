using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RankingCore.Persistence.Models
{
    public class Player
    {
        public int Id { get; set; }
        public Guid UniquePlayerIdentifier { get; set; }
        public string PlayerName { get; set; }
        public int TotalScore { get; set; }
        public int HighScore { get; set; }
        public DateTime? LastScoreDate { get; set; }
        public DateTime? LastHighScoreDate { get; set; }
        public virtual ICollection<Score> Scores { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
