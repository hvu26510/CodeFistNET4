using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFistNET4.Models.DataModels
{
    [Table("KhachHang", Schema = "QLKH")]
    public class KhachHang
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Phone]
        public string PhoneNumber {  get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Address { get; set; }

        [ForeignKey("LoaiKhachHang")]
        public int LoaiKHID { get; set; }
        public virtual LoaiKhachHang LoaiKhachHang { get; set; }

        public int idAccount { get; set; }
        public virtual Account Account { get; set; }    

    }
}
