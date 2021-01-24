    public class PreferencesShoppingCartViewModel
    {
        public List<CartItemPreference> CartItemPreferences { get; set; }
    
        public List<SelectListItem> PreferenceOptions { get; set; }
    
        public PreferencesShoppingCartViewModel()
        {   
            CartItemPreferences = new List<CartItemPreference>();
            PreferenceOptions = new List<SelectListItem>();
        }
    }
    
    public class CartItemPreference
    {
        public string Selected { get; set; }
        public CartItem CartItem { get; set; }
    }
    
    public class CartItem
    {
        public string Sample { get; set; }
    }
