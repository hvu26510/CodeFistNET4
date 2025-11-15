using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFistNET4.Models.DataModels
{
    [Table("LoaiKH", Schema ="QLKH")]
    public class LoaiKhachHang
    {
        [Key]
        public int Id { get; set; }
        public string TenLoaiKH { get; set; }
    }
}
