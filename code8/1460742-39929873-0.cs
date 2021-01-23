    [PSerializable]
    public sealed class CustomLog : OnMethodBoundaryAspect
    {
        public CustomLog()
        {
            ApplyToStateMachine = true;
        }
    
        public override void OnSuccess(MethodExecutionArgs args)
        {
            var stringBuilder = new StringBuilder();
            var declaringType = args.Method.DeclaringType;
    
            stringBuilder.Append("Exiting ");
            stringBuilder.Append(declaringType.FullName);
            stringBuilder.Append('.');
            stringBuilder.Append(args.Method.Name);
    
            if (!args.Method.IsConstructor && ((MethodInfo) args.Method).ReturnType != typeof(void))
            {
                stringBuilder.Append(" with return value ");
                stringBuilder.Append(args.ReturnValue);
            }
    
            Logger.WriteLine(stringBuilder.ToString());
        }
    }
