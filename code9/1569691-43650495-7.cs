    public class GenericDevice
    {
        protected bool isReadOnly;
        public bool IsReadOnly
        {
            get { return isReadOnly; }
            set
            {
                if (isReadOnly && !value)
                {
                    throw new NotSupportedException();
                }
                isReadOnly = value;
            }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (isReadOnly)
                {
                    throw new NotSupportedException();
                }
                name = value;
            }
        }
        private byte[] cmd_1;
        public byte[] CMD_1
        {
            get { return cmd_1; }
            set
            {
                if (isReadOnly)
                {
                    throw new NotSupportedException();
                }
                cmd_1 = value;
            }
        }
        private byte[] cmd_2;
        public byte[] CMD_2
        {
            get { return cmd_2; }
            set
            {
                if (isReadOnly)
                {
                    throw new NotSupportedException();
                }
                cmd_2 = value;
            }
        }
    }
