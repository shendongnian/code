    class Parameter
    {
        public string ParamName;
        public short ParamId;
        public DataType Datatype;
        public ReadWriteState ReadWrite;
        public Parameter(string name,short id,DataType dt,ReadWriteState rw)
        {
            this.ParamName = name;
            this.ParamId = id;
            this.Datatype = dt;
            this.ReadWrite = rw;
        }
    }
