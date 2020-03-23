using System;
using System.Collections.Generic;
using System.Text;

namespace DTBlog.Data.Model
{
    public abstract class BaseModel
    {
        public DateTime CreatedDate { get; set; }
        public DateTime ChangedDate { get; set; }
        public int ChangedUser { get; set; }
        public int UserId { get; set; }
        public UserModel UserModel { get; set; }
    }
}
