    public class Answer<T>
    {
        public T result {get;set;}
        public bool success {get;set;}
    }
    
    public async Task<Answer<MyRecord>> Get(string SomeKey)
    {
        var answer = new Answer<MyRecord>();
        if(ExistsInDB(SomeKey))
        {
            answer.result = await SomeRecordFromDB(SomeKey);
            answer.success = true;
        }
        return answer;
    }
