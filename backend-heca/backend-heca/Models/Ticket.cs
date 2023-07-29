using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_heca.Models
{
    /*[PrimaryKey(nameof(userId),nameof(trainId))]
    [NotMapped]*/
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        public User userId { get; set; }
        public Train trainId { get; set; }
    }
}
