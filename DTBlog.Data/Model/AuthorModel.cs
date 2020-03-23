using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTBlog.Data.Model
{
    [Table("Authors")]
    public class AuthorModel : BaseModel
    {
        public int Id { get; set; }
        public string AuthorFullName { get; set; }
        public string AuthorBio { get; set; }
        public byte[] AuthorImage { get; set; }
        public virtual ICollection<PostModel> PostModels { get; set; }
    }
}
