    public class Answer<T>
    {
        public T result {get;set;}
        public bool success {get;set;}
        public string exception {get;set;}
    }
    
    public async Task<Answer<MyRecord>> Get(string SomeKey)
    {
        var answer = new Answer<MyRecord>();
        try
        {     
            if(ExistsInDB(SomeKey))
            {
                answer.result = await SomeRecordFromDB(SomeKey);
                answer.success = true;
            }
        }
        catch(Exception e)
        {
            answer.exception = e.Message;            
        }
        return answer;
    }
