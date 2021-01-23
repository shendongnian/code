    public int? value;
    OnConsume1()
    {
            while (running)
            {
                    int myValue;
                    if(value != null) // or value.HasValue
                    {
                        myValue = value.Value; // or (int)value
                        value = null; // let other consumers know the value is being processed
                        // do something with data
                    }
                    Thread.Sleep(10);
            }
    }
