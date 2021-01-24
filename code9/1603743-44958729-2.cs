    protected override void Configure()
    {
        ActionMessage.InvokeAction = delegate(ActionExecutionContext context)
        {
            RefreshableActionMessage refreshableActionMessage;
    
            object[] parameters = MessageBinder.DetermineParameters(context, context.Method.GetParameters());
            object obj = context.Method.Invoke(context.Target, parameters);
            Task task = obj as Task;
            if (task != null)
            {
                obj = task.AsResult();
            }
            IResult result = obj as IResult;
            if (result != null)
            {
                obj = new IResult[]
    		    {
    			    result
    		    };
            }
            IEnumerable<IResult> enumerable = obj as IEnumerable<IResult>;
            if (enumerable != null)
            {
                obj = enumerable.GetEnumerator();
            }
            IEnumerator<IResult> enumerator = obj as IEnumerator<IResult>;
            if (enumerator != null)
            {
                Coroutine.BeginExecute(enumerator, new CoroutineExecutionContext
                {
                    Source = context.Source,
                    View = context.View,
                    Target = context.Target
                }, null);
            }
    
            refreshableActionMessage = context.Message as RefreshableActionMessage;
            if (refreshableActionMessage != null && refreshableActionMessage.RefreshAfterInvoke)
            {
                refreshableActionMessage.UpdateAvailability();
            }
        };
    }
