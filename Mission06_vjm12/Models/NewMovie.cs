using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
//Create model to use for database and form inputs, use required fields and max string length
namespace Mission06_vjm12.Models
{
    public class NewMovie
    {
        [Key]
        [Required]
        public int MovieID { get; set; }
        [Required(ErrorMessage ="Please enter a movie title.")]
        public string MovieTitle { get; set; }
        [Required(ErrorMessage ="Please enter the year the movie was made.")]
        public int Year { get; set; }
        [Required(ErrorMessage ="Please enter the name of the movie director.")]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }
        public bool Edited { get; set; }
        public string LentTo { get; set; }
        [StringLengthAttribute(25)]
        public string Notes { get; set; }

        //Build foreign key relationship
        [Required]
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
