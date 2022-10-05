namespace GG.Models
{
    public class Sport
    {
        public int id { get; set; }

        public string sportName { get; set; }

        public String description { get; set; }
        public List<Player>? players { get; set; }
        public List<Refree>? refrees { get; set; }
        public List<Playground>? playgrounds { get; set; }
    }
}
