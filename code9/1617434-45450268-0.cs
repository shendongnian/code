    public static Task<SomeObject> Deserialize(string filePath)
        {
            var task = Task.Factory.StartNew(() => LoadFile(filePath));
    
            return task;       
        }
