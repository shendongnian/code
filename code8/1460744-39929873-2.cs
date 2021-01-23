    [PSerializable]
    public sealed class CustomLog : OnMethodBoundaryAspect
    {
        public override void OnExit(MethodExecutionArgs args)
        {
            if (!args.Method.IsConstructor && (((MethodInfo) args.Method).ReturnType != typeof(void)))
            {
                var task = args.ReturnValue as Task;
                if (task != null)
                {
                    task.ContinueWith(originalTask =>
                    {
                        var taskType = originalTask.GetType();
                        object returnValue = taskType.GetProperty("Result")?.GetValue(originalTask, null);
                        LogExit(args, returnValue);
                    });
                }
                else
                {
                    LogExit(args, args.ReturnValue);
                }
            }
        }
    
        private static void LogExit(MethodExecutionArgs args, object returnValue)
        {
            var stringBuilder = new StringBuilder();
            var declaringType = args.Method.DeclaringType;
    
            stringBuilder.Append("Exiting ");
            stringBuilder.Append(declaringType.FullName);
            stringBuilder.Append('.');
            stringBuilder.Append(args.Method.Name);
    
            stringBuilder.Append(" with return value ");
            stringBuilder.Append(returnValue);
    
            Logger.WriteLine(stringBuilder.ToString());
        }
    }
