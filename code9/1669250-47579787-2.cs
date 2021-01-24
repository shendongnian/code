    private void OnPasswordChanged(object sender, RoutedEventArgs e) {            
        using (var pwd = ((PasswordBox) sender).SecurePassword) {
            int length = pwd.Length;
            if (length == 0) {
                // string empty, do something
                return;
            }
            bool hasSpecial = false;
            bool hasUpper = false;
            bool hasLower = false;
            bool hasDigit = false;
            // etc
            // allocate unmanaged memory and copy string there
            IntPtr ptr = Marshal.SecureStringToBSTR(pwd);
            try {
                // each char in that string is 2 bytes, not one (it's UTF-16 string)
                for (int i = 0; i < length * 2; i += 2) {
                    // so use ReadInt16 and convert resulting "short" to char
                    var ch = Convert.ToChar(Marshal.ReadInt16(ptr + i));
                    // run your checks
                    hasSpecial |= IsSpecialChar(ch);
                    hasUpper |= Char.IsUpper(ch);
                    hasLower |= Char.IsLower(ch);
                    hasDigit |= Char.IsDigit(ch);                        
                }
            }
            finally {
                // don't forget to zero memory to remove password from it                    
                Marshal.ZeroFreeBSTR(ptr);
            }
        }
    }
