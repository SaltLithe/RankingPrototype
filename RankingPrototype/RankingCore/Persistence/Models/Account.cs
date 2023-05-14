using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RankingCore.Persistence.Models
{
    public class Account
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public string AccountId { get; set; }
        public Guid UniquePlayerIdentifier { get; set; }
        public AccountType  AccountType { get; set; }
    }
}
