    public class AccountViewModel : IValidatableObject
    {
        [Display(Name = "Mật khẩu cũ")]
        public string OldPassword { get; set; }
        [Display(Name = "Mật khẩu mới")]
        public string NewPassword { get; set; }
        [Display(Name = "Xác nhận mật khẩu mới")]
        [Compare("NewPassword", ErrorMessage = "Mật khẩu xác nhận không trùng khớp")]
        public string NewPasswordConfirm { get; set; }
    
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (// Do something here)
            {
                yield return new ValidationResult("Error Message");
            }
        }
    }
    public ActionResult ModifyAccount()
    {
        if (!ModelState.IsValid)
        {
        }
        
    }
