    public void MapContact(ref Contact contactInfo)
    {
    	List<Task> taskList = new List<Task>();
    	Contact pro = contactInfo;
    	taskList.Add(Task.Factory.StartNew(() => 
            { pro.profileInfo = new Profile() 
                { 
                    FirstName = "Stack", 
                    LastName = "Overflow" 
                }; 
            }));
    	Task.WaitAll(taskList.ToArray());
    }
