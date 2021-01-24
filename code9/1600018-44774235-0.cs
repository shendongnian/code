    public void AddTaskToCheckList(int id)
    {
        // Find task
        var task = this.Tasks.Find(id);
        if(!this.CheckList.Contains(task))
        {
            this.CheckList.Add(task);
        } 
        else
        {
            // Show error message        
        }   
    }
