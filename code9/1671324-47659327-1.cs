    public class SampleService:ISampleService   
    {   
       // ...  
       public async Task<string> SampleMethodTaskAsync(string msg)   
       {   
          return Task<string>.Factory.StartNew(() =>   
          {   
             return msg;   
          });   
       }  
       // ...  
    }  
