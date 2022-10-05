using System.ComponentModel.DataAnnotations.Schema;

namespace GG.Models
{
    public class Refree
    {
        public int Id { get; set; }
        public string refreeName { get; set; }
        public string refreeNumber { get; set; }
        public string emailAddress { get; set; }

        [ForeignKey("groundId")]
        public Playground? Playground { get; set; }
        public int? groundId { get; set; }

        [ForeignKey("sportId")]
        public Sport? Sport { get; set; }
        public int? sportId { get; set; }
    }
}
