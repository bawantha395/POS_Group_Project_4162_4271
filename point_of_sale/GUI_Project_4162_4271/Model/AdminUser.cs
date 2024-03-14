namespace GUI_Project_4162_4271.Model
{
    public class AdminUser
    {
        public string AdminUserName { get; set; }
        public int AdminUserPassword { get; set; }
        public int AdminId { get; set; }
        public UserType UserType { get; set; }
    }

    public enum UserType
    {
        Admin,
        Normal
    }
}
