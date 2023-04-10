using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UrlShortener.Models
{
    public class CustomUrlModel
    {
        [Required]
        public string OriginalUrl { get; set; }
        [Required]
        [MaxLength(6,ErrorMessage ="maximum 6 chars")]
        [MinLength(6,ErrorMessage = "minimum 6 chars")]
        [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "Use letters and 1-9 numbers only please")]
        public string CustomUrl { get; set; }
    }
}
