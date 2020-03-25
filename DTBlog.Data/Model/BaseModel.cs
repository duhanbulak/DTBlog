using System;
using System.Collections.Generic;
using System.Text;

namespace DTBlog.Data.Model
{
    public abstract class BaseModel
    {
        public DateTime CreatedDate { get; set; }
        public DateTime ChangedDate { get; set; }
        public int ChangedUserId { get; set; }
        public virtual UserModel ChangedUser { get; set; }
        public int UserId { get; set; }
        public virtual UserModel UserModel { get; set; }
    }
}
