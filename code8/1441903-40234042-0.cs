    [DisplayResourceHost(typeof(Localization.Account))]
    public class ViewModel
    {
        [Display(NameResource = Localization.Account.MinPasswordLength)]
        public int MinPasswordLength { get; set; }
    }
