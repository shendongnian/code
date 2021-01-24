    //this one is used to map the C# class-object to Oracle UDT
    public virtual void FromCustomObject(OracleConnection conn, IntPtr object){
        OracleUdt.SetValue(conn, object, "MyNumber", this.cNumber);
    }
    
    //and this one is used to convert Oracle UDT to C# class
    public virtual void ToCustomObject(OracleConnection conn, IntPtr object){
        this.cNumber = ((int)(OracleUdt.GetValue(conn, object, "MyNumber")));
    }
