namespace CodeFistNET4.Models.DataModels
{
    public class Account
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    
        public KhachHang khachHang { get; set; }

    }
}
