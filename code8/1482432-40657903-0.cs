    public static MasterEmailSettings Create(string path){
        try{
            return JsonConvert.DeserializeObject<MasterEmailSettings>(File.ReadAllText(path))
        }
        catch(IOException ex)
        {
            //Answer how the system should respond in the event that the file did not exist. Maybe you just want to log it and throw?
            throw; //Do not use throw ex as it will re-start the stack trace from the point the exception is thrown. Use either throw or throw new SomeException("", ex); to make sure the original stack trace on the exception is preserved.
        }
    }
