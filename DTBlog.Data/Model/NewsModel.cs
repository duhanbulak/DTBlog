using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DTBlog.Data.Model
{
    [Table("News")]
    public class NewsModel : BaseModel
    {
        public int Id { get; set; }

        [Required]
        public string NewsTitle { get; set; }

        [Required]
        public string NewsContent { get; set; }

        public byte[] NewsImage { get; set; }

        [Required]
        public bool NewsStatus { get; set; }
    }
}
