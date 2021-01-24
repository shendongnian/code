            //create task service instance
            TaskScheduler.TaskScheduler taskService = new TaskScheduler.TaskScheduler();
            taskService.Connect();
            ITaskDefinition taskDefinition = taskService.NewTask(0);
            taskDefinition.Settings.Enabled = true;
            taskDefinition.RegistrationInfo.Author = "Desklight";
            taskDefinition.Principal.RunLevel = _TASK_RUNLEVEL.TASK_RUNLEVEL_LUA;
            taskDefinition.Settings.AllowDemandStart = true;
            taskDefinition.Settings.StartWhenAvailable = true;
            taskDefinition.Settings.DisallowStartIfOnBatteries = false;
            taskDefinition.Settings.Compatibility = _TASK_COMPATIBILITY.TASK_COMPATIBILITY_V2_4;
            //create trigger for task creation.
            ITriggerCollection _iTriggerCollection = taskDefinition.Triggers;
            ISessionStateChangeTrigger sessionStateChangeTrigger = (ISessionStateChangeTrigger)_iTriggerCollection.Create(_TASK_TRIGGER_TYPE2.TASK_TRIGGER_SESSION_STATE_CHANGE);
            sessionStateChangeTrigger.Id = "UnlockTrigger";
            sessionStateChangeTrigger.StateChange = _TASK_SESSION_STATE_CHANGE_TYPE.TASK_SESSION_UNLOCK;
            sessionStateChangeTrigger.UserId = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            sessionStateChangeTrigger.Enabled = true;
            //get actions.
            IActionCollection actions = taskDefinition.Actions;
            _TASK_ACTION_TYPE actionType = _TASK_ACTION_TYPE.TASK_ACTION_EXEC;
            //create new action
            IAction action = actions.Create(actionType);
            IExecAction execAction = action as IExecAction;
            execAction.Path = getExecutable(silent);
            ITaskFolder rootFolder = taskService.GetFolder(@"\");
            //register task.
            const int TASK_CREATE_OR_UPDATE = 6;
            string taskName = "Desklight-" + Environment.UserName;
            rootFolder.RegisterTaskDefinition(taskName, taskDefinition, TASK_CREATE_OR_UPDATE, null, null, _TASK_LOGON_TYPE.TASK_LOGON_NONE, null);
