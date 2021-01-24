    // Use these methods in PopupNavigation globally or Navigation in your pages
    
    // Open new PopupPage
    Task PushAsync(PopupPage page, bool animate = true) // Navigation.PushPopupAsync
    
    // Hide last PopupPage
    Task PopAsync(bool animate = true) // Navigation.PopPopupAsync
    
    // Hide all PopupPage with animations
    Task PopAllAsync(bool animate = true) // Navigation.PopAllPopupAsync
    
    // Remove one popup page in stack
    Task RemovePageAsync(PopupPage page, bool animate = true) // Navigation.RemovePopupPageAsync
