using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DadJokesAPI.Models
{
    public class Joke
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Category { get; set; }

        public string Setup { get; set; } 

        public string Punch { get; set; }
                
    }
}
