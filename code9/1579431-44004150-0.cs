    void TheOuterFunction() 
    {
        // your cmd is set up here
        var cmd = ...;
        ...;
    
        AddParameter("@AccountNum", data.Account_Num);
        AddParameter("@publisher", data.publisher);
        ...;
       
        void AddParameter(string name, string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                cmd.Parameters.AddWithValue(name, "");
            }
            else
            {
                cmd.Parameters.AddWithValue(name, value);
            }
        }
    }
