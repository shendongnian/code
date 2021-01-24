    internal class MachineKeyDataProtector : IDataProtector
    {
        private readonly string[] _purposes;
    
        public MachineKeyDataProtector(params string[] purposes)
        {
            _purposes = purposes;
        }
    
        public virtual byte[] Protect(byte[] userData)
        {
            return MachineKey.Protect(userData, _purposes);
        }
    
        public virtual byte[] Unprotect(byte[] protectedData)
        {
            return MachineKey.Unprotect(protectedData, _purposes);
        }
    }
