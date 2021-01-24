    /// <summary>
    /// Start from Control and move through all inside controls to check if can execute and 
    /// execute ctrlAction if canExecute results true
    /// </summary>
    /// <typeparam name="T">
    /// Any Control or object inherits System.Web.UI.Control
    /// </typeparam>
    /// <param name="ctrl">
    /// the System.Web.UI.Control to traverse from and inside
    /// </param>
    /// <param name="ctrlAction">
    /// the action to execute on the valid control
    /// </param>
    /// <param name="canExecute">
    /// to check if the current reached control is valid for ctrlAction execution
    /// </param>
    public static void ExApply<T>(
    	this Control ctrl, Action<T> ctrlAction, Predicate<T> canExecute = null) where T : Control
    {
    	// if ctrl is null return null
    	if (ctrl == null) { return; }
    	// to handle multitasking on the valid controls
    	LinkedList<Task> taskList = new LinkedList<Task>();
    	// start control traverse through all controls from and inside
    	ctrl._exApply(canExecute, ctrlAction, taskList);
    	// Waiting not finished, clean and clear resources
    	taskList._exWaitAndDispose();
    }
    
    /// <summary>
    /// Start from ControlCollection and move through all inside controls to check if can execute and 
    /// execute ctrlAction if canExecute results true
    /// </summary>
    /// <typeparam name="T">
    /// Any Control or object inherits System.Web.UI.Control
    /// </typeparam>
    /// <param name="ctrls">
    /// the System.Web.UI.ControlCollection to traverse from and inside
    /// </param>
    /// <param name="ctrlAction">
    /// the action to execute on the valid control
    /// </param>
    /// <param name="canExecute">
    /// to check if the current reached control is valid for ctrlAction execution
    /// </param>
    public static void ExApply<T>(
    	this ControlCollection ctrls, Action<T> ctrlAction, Predicate<T> canExecute = null)
    	where T : Control
    {
    	// if ctrls is null return null
    	if (ctrls == null) { return; }
    	// to handle multitasking on the valid controls
    	LinkedList<Task> taskList = new LinkedList<Task>();
    	// start control traverse through all controls from and inside
    	ctrls._exApply(canExecute, ctrlAction, taskList);
    	// Waiting not finished, clean and clear resources
    	taskList._exWaitAndDispose();
    }
    
     private static void _exApply<T>(
    	this Control ctrl, Predicate<T> canExecute, Action<T> ctrlAction, LinkedList<Task> taskList)
    	where T : Control
    {
    	// if ctrl is null no more moves needed
    	if (ctrl == null) { return; }
    
    	// if ctrl can be casted and has no empty id
    	if ((ctrl is T castedCtrl) && castedCtrl.ID.ExIsNotNone())
    	{
    		// if canExecute is null or returned true result
    		if (canExecute == null || (canExecute != null && canExecute(castedCtrl)))
    		{
    			// add castedCtrl as an asynchronous task
    			taskList.AddLast(Task.Run(() => ctrlAction(castedCtrl)));
    			// check first node task if completed to remove and dispose
    			taskList._exDisposeFirsts();
    		}
    	}
    
    	// move more deep into inside controls 
    	if (ctrl.Controls != null && ctrl.Controls.Count > 0)
    	{
    		ctrl.Controls._exApply(canExecute, ctrlAction, taskList);
    	}
    }
    
    private static void _exApply<T>(
    	this ControlCollection ctrls, Predicate<T> canExecute, Action<T> ctrlAction,
    	LinkedList<Task> taskList) where T : Control
    {
    	for (int index = 0; index < ctrls.Count; index++)
    	{
    		// move through control to validate and apply ctrlAction
    		ctrls[index]?._exApply(canExecute, ctrlAction, taskList);
    	}
    }
    
    private static void _exDisposeFirsts(this LinkedList<Task> taskList)
    {
    	while (taskList.Count > 0 && taskList.First.Value.IsCompleted)
    	{
    		taskList.First.Value.Dispose();
    		taskList.RemoveFirst();
    	}
    }
    
    private static void _exWaitAndDispose(this LinkedList<Task> taskList)
    {
    	taskList._exDisposeFirsts();
    	if (taskList.Count < 1) { return; }
    	Task[] tasks = new Task[taskList.Count];
    	taskList.CopyTo(tasks, 0);
    	taskList.Clear();
    	Task.WaitAll(tasks);
    	tasks.ExDispose();
    }
    
    /// <summary>
    /// Smaller Size name and usage from "string.IsNullOrWhiteSpace(text)" Indicates whether a 
    /// specified string is null, empty, or consists only of white-space characters.
    /// </summary>
    /// <param name="text">The string to test</param>
    /// <returns>
    /// true if the value parameter is null or System.String.Empty, or if value consists 
    /// exclusively of white-space characters.
    /// </returns>
    public static bool ExIsNone(this string text) => string.IsNullOrWhiteSpace(text);
    
    /// <summary>
    /// Smaller Size name and usage from "!string.IsNullOrWhiteSpace(text)" Indicates whether a 
    /// specified string is not null, not empty, or not consists only of white-space characters.
    /// </summary>
    /// <param name="text">The string to test</param>
    /// <returns>
    /// true if the value parameter is not null or not System.String.Empty, or if value not consists 
    /// exclusively of white-space characters.
    /// </returns>
    public static bool ExIsNotNone(this string text) => text.ExIsNone().ExIs(false);
    
    /// <summary>
    /// Use for easier code reading instead of inverse ! character and ambiguous names
    /// </summary>
    /// <param name="value">value to test</param>
    /// <param name="compareValue">value to compare with</param>
    /// <returns>true is equal otherwise false</returns>
    public static bool ExIs(this bool value, bool compareValue) => value == compareValue;
