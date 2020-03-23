using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTBlog.Data.Model
{
    [Table("QuotationModel")]
    public class QuotationModel : BaseModel
    {
        public int Id { get; set; }

        [Required]
        public string QuoteContent { get; set; }

        [Required]
        public string QuoteFrom { get; set; }

        public byte[] QuoteImage { get; set; }
    }
}
