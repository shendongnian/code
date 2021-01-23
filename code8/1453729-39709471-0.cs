    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Threading;
    
    namespace BackGroundTask
    {
    	public class TaskManager
    	{
    		//The instance property
    		private static TaskManager instance;
    		public static TaskManager Instance{
    			get{
    				if(null == instance)
    					instance = new TaskManager();
    				return instance;
    			}
    		}
    
    		private bool actionTaskFreeFlag = true;//Flag for if actionTask is available or not
    
    		private Queue<Action> taskQueue;//A queue to collect the tasks you added into the manager
    		private Task scanTask;//A Task to sacn the queue
    		private Task actionTask;//A task to do the current action
    		private Thread actionTaskRunningThread;//Record the thread that current action is working on 
    
    		public TaskManager()
    		{
    			taskQueue = new Queue<Action>();
    
    			scanTask = new Task(() =>
    			{
    				while (true)
    				{
    					if (actionTaskFreeFlag && taskQueue.Count > 0)//If there still something to do and the actionTask is available then do the action
    					{
    						actionTaskFreeFlag = false;
    						Action action = taskQueue.Dequeue();
    						actionTask = new Task(() => {
    							actionTaskRunningThread = System.Threading.Thread.CurrentThread;
    							action();
    						});
    						actionTask.Start();
    						actionTask.ContinueWith(delegate {
    							actionTaskFreeFlag = true;
    						});
    					}
    				}
    			});
    			scanTask.Start();
    		}
    
    		public void AddAction(Action action) 
    		{
    			taskQueue.Enqueue(action);
    		}
    
    		public void CancelCurrentTaskAndClearTaskQueue()
    		{
    			Console.WriteLine("CancelCurrentTaskAndClearTaskQueue");
    			if(null != actionTaskRunningThread)
    				actionTaskRunningThread.Abort();
    			taskQueue.Clear();
    		}
    	}
    }
