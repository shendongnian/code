    var TaskList = new List<Task>();
    //list is populated here, however you're gonna do that
    //this is a boolean, in case that's not clear
    var isProjectWorkspaceUrlPopulated = TaskList.Any(q => !string.IsNullOrEmpty(q.ProjectWorkspaceUrl));
    if(isProjectWorkspaceUrlPopulated)
      {
        //...something happens, one supposes
      }
     else
      {
       //.... maybe something else?
      }
