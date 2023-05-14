namespace RankingCore.ViewEntities
{
    public class PlayerDetails
    {
        public int Id { get; set; }
        public Guid UniquePlayerIdentifier { get; set; }
        public string PlayerName { get; set; }
        public int TotalScore { get; set; }
        public int HighScore { get; set; }
        public DateTime? LastScoreDate { get; set; }
        public DateTime? LastHighScoreDate { get; set; }
    }
}