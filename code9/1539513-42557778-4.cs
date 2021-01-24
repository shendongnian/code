    public class LoginModel{
    [Required(ErrorMessage = "Username cannot be empty")]
    public string UserName { get; set; }
    [Required(ErrorMessage = "Password cannot be empty")]
    public string Password { get; set; }
    }
