    public string QlasrPostcommit(string si, string sp, string variant = null)
        {
     Task<string > task = Task.Run<string >(async () => await 
          DPR.QlasrPostcommit(si, sp, variant));
          task.Result;    
        }
