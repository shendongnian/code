    public event EventHandler<TaskResult> TaskCompleted;
    
    public async Task CreateAsync(ApplicationUser user)
    {
        var result = await Task.Run(() => _dal.CreateUser(user.UserName));
        this.OnTaskCompleted(result);
    }
    private void OnTaskCompleted(TaskResult result)
    {
        this.TaskCompleted?.Invoke(this, result);
    }
