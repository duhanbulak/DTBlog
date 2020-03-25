using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DTBlog.Data.Model
{
    [Table("Users")]
    public class UserModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        public string PhoneNumber { get; set; }

        [EmailAddress, Required]
        public string MailAddress { get; set; }

        [MinLength(5), Required]
        public string Password { get; set; }

        public bool IsSuperAdmin { get; set; }

        public virtual ICollection<PostModel> PostModels { get; set; }
        public virtual ICollection<PostModel> ChangeUserPost { get; set; }
        public virtual ICollection<MusicModel> MusicModels { get; set; }
        public virtual ICollection<MusicModel> ChangeUserMusic { get; set; }
        public virtual ICollection<NewsModel> NewsModels { get; set; }
        public virtual ICollection<NewsModel> ChangeUserNews { get; set; }
        public virtual ICollection<AuthorModel> AuthorModels { get; set; }
        public virtual ICollection<AuthorModel> ChangeUserAuthor { get; set; }
        public virtual ICollection<QuotationModel> QuotationModels { get; set; }
        public virtual ICollection<QuotationModel> ChangeUserQuot { get; set; }
    }
}
