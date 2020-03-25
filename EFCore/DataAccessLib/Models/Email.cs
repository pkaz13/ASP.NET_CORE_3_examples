using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLib.Models
{
    public class Email
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string EmailAddress { get; set; }

        [Required]
        [ForeignKey("Person")]
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
