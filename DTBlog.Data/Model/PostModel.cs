using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;
using System.Text;

namespace DTBlog.Data.Model
{
    [Table("Posts")]
    public class PostModel : BaseModel
    {
        public int Id { get; set; }

        [Required]
        public string PostTitle { get; set; }

        [Required]
        public string PostContent { get; set; }

        public byte[] PostImage { get; set; }

        [Required]
        public bool PostStatus { get; set; }

        public int AuthorId { get; set; }

        public AuthorModel AuthorModel { get; set; }
    }
}
