using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuotesAPI.Models
{
    public class Quote
    {
        public int Id { get; set; }

        [Required, MinLength(3), MaxLength(255)]
        public string Title { get; set; }

        [Required, MinLength(3)]
        public string Author { get; set; }

        [Required, MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
    }
}