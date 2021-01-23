        public static Icon IconFromExtension(string extension,
                                                SystemIconSize size)     
        {
            try
            {
                // Add the '.' to the extension if needed
                if (extension[0] != '.') extension = '.' + extension;
                //opens the registry for the wanted key.
                RegistryKey Root = Registry.ClassesRoot;
                RegistryKey ExtensionKey = Root.OpenSubKey(extension);
                ExtensionKey.GetValueNames();
                RegistryKey ApplicationKey =
                    Root.OpenSubKey(ExtensionKey.GetValue("").ToString());
                //gets the name of the file that have the icon.
                string IconLocation =
                    ApplicationKey.OpenSubKey("DefaultIcon").GetValue("").ToString();
                string[] IconPath = IconLocation.Split(',');
                if (IconPath[1] == null) IconPath[1] = "0";
                IntPtr[] Large = new IntPtr[1], Small = new IntPtr[1];
                //extracts the icon from the file.
                ExtractIconEx(IconPath[0],
                    Convert.ToInt16(IconPath[1]), Large, Small, 1);
                return size == SystemIconSize.Large ?
                    Icon.FromHandle(Large[0]) : Icon.FromHandle(Small[0]);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
