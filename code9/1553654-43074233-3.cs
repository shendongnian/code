    public static MessageBoxResult Show(String caption, String message, 
        MessageBoxButtons button, MessageBoxImage icon)
    {
        return Show(caption, message, ConvertToMyMessageBoxButton(button), icon);
    }
