    StringBuilder sb = new StringBuilder();
    for (int i = 0; i < 10; i++)
    {
        try
        {
            var bytes = File.ReadAllBytes(dirPath + string.Format(@"commands{0}.txt", i));
    
            sb.Append(Environment.NewLine);
            sb.Append(System.Text.Encoding.UTF8.GetString(bytes));    
            //avoid sb.Append(Environment.NewLine + System.Text.Encoding.UTF8.GetString(bytes)) 
            //because you still create unnecessary object doing concatenation (+)    
        }
        catch (Exception e)
        {
            //OutOfMemory exception
        }
    }
    
    //you can cast sb to "string"
    string res = sb.ToString();
