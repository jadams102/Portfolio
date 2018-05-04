using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Portfolio.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        public string title { get; set; }
        public DateTime date { get; set; }
        public string body { get; set; }
    }
}
