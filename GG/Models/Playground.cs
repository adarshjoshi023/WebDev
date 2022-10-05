using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GG.Models
{
    public class Playground
    {
        public int Id { get; set; }
        public string groundName { get; set; }
        public string location { get; set; }

        [DataType(DataType.Date)]
        public DateTime date { get; set; }

        [DataType(DataType.Time)]
        public DateTime time { get; set; }

        [ForeignKey("sportId")]
        public Sport? Sport { get; set; }
        public int? sportId { get; set; }
        public List<Player>? players { get; set; }
        public List<Refree>? refrees { get; set; }
    }
}
