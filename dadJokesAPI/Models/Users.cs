using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DadJokesAPI.Models
{
    public class Users
    {
        [Key]
        public int Userid { get; set; }

        public string Pass {get; set;}
    }
}
