using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Portfolio.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public string User { get; set; }
        public string Body { get; set; }
        public int PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}
