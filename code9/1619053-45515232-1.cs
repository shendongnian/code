    public void Caller()
    {
        yield return StartCoroutine(Login());
        // Login finished, check the login credentials
    }
    
    private IEnumerator WaitTask(Task task)
    {
        while (task.IsCompleted == false)
        {
            yield return null;
        }
        if(task.IsFaulted)
        {
            throw task.Exception;
        }
    }
    
    public IEnumerator Login()
    {
        Task<DataSnapshot> getKeyTask = Database.Child("keyLocation").GetValueAsync();
    
        yield return WaitTask(getKeyTask);
    
        Task loginTask = Auth.SignInWithEmailAndPasswordAsync(getKeyTask.Result.___.username, getKeyTask.Result.____.password);
    
        yield return WaitTask(loginTask);
    
        //... the next task can use loginTask.Result etc.
    
    }
