    public async Task<IHttpActionResult> doSomething(arguments)
        {  
         bool isInsertDone ,isUpdateDone = false;
         //create thread list
          var task = new List<Task>();
          // parallel tasks to thread list and execute that tasks 
           task.Add(Task.Run(() =>
              {`enter code here`
                  isInsertDone = insertData(arguments)
               }));
               task.Add(Task.Run(() =>
               {
                  isUpdateDone  updateData(arguments)
               }));
             
            // wait for execute all above tasks
             Task.WaitAll(task.ToArray());
            
            // return response by result of insert and update.
            return Ok<bool>(isInsertDone && isUpdateDone);
        }
