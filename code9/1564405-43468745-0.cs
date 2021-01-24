    public void WriteData( , , List<string> source, , ) { WriteData<string>(...); }
    public void WriteData( , , List<byte> source, , ) { WriteData<byte>(...); }
    public void WriteData( , , List<double> source, , ) { WriteData<double>(...); }
    private void WriteData<T>( , , List<T> source, , ) 
    { 
        Debug.Assert(typeof(T).Equals(typeof(string)) ||
                     typeof(T).Equals(typeof(byte)) ||
                     typeof(T).Equals(typeof(double)));
        ...
    }
