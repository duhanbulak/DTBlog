using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DTBlog.Data.Model
{
    [Table("Musics")]
    public class MusicModel : BaseModel
    {
        public int Id { get; set; }
        public string MusicLink { get; set; }
    }
}
