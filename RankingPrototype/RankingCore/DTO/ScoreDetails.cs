namespace RankingCore.ViewEntities
{
    public class ScoreDetails
    {
        public int PlayerId { get; set; }
        public Guid UniquePlayerIdentifier { get; set; }
        public int ScoreAmount { get; set; }
        public DateTime ScoreRegisterDate { get; set; }
    }
}