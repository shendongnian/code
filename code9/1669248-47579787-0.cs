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
            // allocate unmanaged memory and copy string there
            IntPtr ptr = Marshal.SecureStringToBSTR(pwd);
            try {
                int offset = 0;
                char ch;
                do {
                    // each char in that string is 2 bytes, not one (unicode string)
                    // so use ReadInt16
                    ch = Convert.ToChar(Marshal.ReadInt16(ptr + offset));                        
                    offset += 2;
                    hasSpecial |= IsSpecialChar(ch);
                    hasUpper |= Char.IsUpper(ch);
                    hasLower |= Char.IsLower(ch);
                    hasDigit |= Char.IsDigit(ch);
                    // etc
                } while (ch != '\0'); // unmanaged string is terminated with 0 char
            }
            finally {
                // don't forget to zero memory to remove password from it
                if (ptr != IntPtr.Zero)
                    Marshal.ZeroFreeBSTR(ptr);
            }
        }            
    }
