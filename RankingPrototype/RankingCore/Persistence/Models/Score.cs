using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RankingCore.Persistence.Models
{
    public class Score
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public Guid UniquePlayerIdentifier { get; set; }
        public int ScoreAmount { get; set; }
        public DateTime ScoreRegisterDate { get; set; }
    }
}
