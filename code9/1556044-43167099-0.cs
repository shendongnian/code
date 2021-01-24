    public class ModifyPasswordViewModel
    {
        [Display(Name = "Mật khẩu cũ")]
        [Required]
        public string OldPassword { get; set; }
        [Display(Name = "Mật khẩu mới")]
        [Required]
        public string NewPassword { get; set; }
        [Display(Name = "Xác nhận mật khẩu mới")]
        [Required]
        [Compare("NewPassword", ErrorMessage = "Mật khẩu xác nhận không trùng khớp")]
        public string NewPasswordConfirm { get; set; }
    }
