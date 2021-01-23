    public override void Set(IDbCommand cmd, object value, int index) {
        var prm = ((IDataParameter) cmd.Parameters[index]);
        if (cmd == null) throw new ArgumentNullException("cmd");
        if (value == null) {
            prm.Value = null;
            return;
        }
        string str;
        try {
            // guid becomes a simple guid string, datetime becomes a simple     
            // datetime string etc. (ymmv per type)
            // note that it will use the currentculture by 
            // default - which is what we want for a datetime anyway
            str = TypeDescriptor.GetConverter(typeof(T)).ConvertToString(value);
        }
        catch (NotSupportedException) {
            throw new NotSupportedException("Unconvertible type " + typeof(T) + " with EncryptedDbString attribute");
        }
        prm.Value = Encryptor.EncryptString(str);
    }
    public override object Get(IDataReader rs, int index) {
            
        if (rs == null) throw new ArgumentNullException("rs");
        var encrypted = rs[index] as string;
        if (encrypted == null) return null;
        var decrypted = Encryptor.DecryptString(encrypted);
        object obj;
        try {
            obj = (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFromString(decrypted);
        }
        catch (NotSupportedException) {
            throw new NotSupportedException("Unconvertible type " + typeof(T) + " with EncryptedDbString attribute");
        }
        catch (FormatException) {
            // consideration - this will log the unencrypted text
            throw new FormatException(string.Format("Cannot convert string {0} to type {1}", decrypted, typeof(T)));
        }
        return obj;
    }
