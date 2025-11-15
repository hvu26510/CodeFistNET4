using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFistNET4.Models.DataModels
{
    public class MaKhuyenMai
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public int percentage { get; set; }

        [ForeignKey("LoaiKhuyenMai")]       
        public int lkmID { get; set; }
        [ValidateNever]
        public virtual LoaiKhuyenMai LoaiKhuyenMai { get; set; }
    }
}
