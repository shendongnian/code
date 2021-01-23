    public interface IProcessor
    {
        void Initialise(
            string param1, 
            string param2, 
            string param2, 
            AuditTail auditTrail, 
            UserInfo userInfo, 
            DirectoryInfo workingDir);
        void ProcessBatch(int uid);
    }
