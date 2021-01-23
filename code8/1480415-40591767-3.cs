    public static void InvokeIfRequired(this ISynchronizeInvoke formControl, MethodInvoker action)
    {
        if (formControl.InvokeRequired) {
            formControl.Invoke(action, new object[0]);
        } else {
            action();
        }
    }
    
