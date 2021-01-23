        public override string ToString()
        {
            StackTrace stackTrace = new StackTrace();           
            StackFrame[] stackFrames = stackTrace.GetFrames();  
    
            StackFrame callingFrame = stackFrames[1];
            MethodInfo method = callingFrame.GetMethod();
            YourLogingMethod(method.DeclaringType.Name + "." + method.Name);
        
            return base.ToString();
        }
