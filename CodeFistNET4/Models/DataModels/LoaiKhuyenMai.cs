using System.ComponentModel.DataAnnotations;

namespace CodeFistNET4.Models.DataModels
{
    public class LoaiKhuyenMai
    {
        [Key]
        public int Id { get; set; }
        public string TenLoaiKM { get; set; }
    }
}
