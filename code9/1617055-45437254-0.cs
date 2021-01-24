        public class MyReg{
        public RegistryKey Foriegnkey {
            get => forignKey;
            set => forignKey = value;
        }
        private RegistryKey forignKey;
     
		public object Read(string Path, string Name) => (Registry.CurrentUser.OpenSubKey(Path, false).GetValue(Name));
	 
		public void Write(string Path, string Name, object Data) {
			Foriegnkey = Registry.CurrentUser.CreateSubKey(Path, RegistryKeyPermissionCheck.Default);
			Foriegnkey.SetValue(Name, Data);
			Foriegnkey.Close();
		}
	  }
