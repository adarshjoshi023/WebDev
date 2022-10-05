using System.ComponentModel.DataAnnotations.Schema;

namespace GG.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string playerName { get; set; }
        public string phoneNumber { get; set; }
        public string emailAddress { get; set; }
        public string skillLevel { get; set; }

        [ForeignKey("groundId")]
        public Playground? Playground { get; set; }
        public int? groundId { get; set; }

        [ForeignKey("sportId")]
        public Sport? Sport { get; set; }
        public int? sportId { get; set; }
    }
}
