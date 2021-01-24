    public class PostsharpAttrAttribute : MethodInterceptionAspect
    {
          bool awaitDirectly = false;
        public override void OnInvoke(MethodInterceptionArgs args)
        {
         
           var asyncAttr = args.Method.GetCustomAttributes<AsyncStateMachineAttribute>();
           if (asyncAttr != null)
           {// is async method
                if (awaitDirectly)
                {
                    base.OnInvoke();
                    var task = (Task)args.ReturnValue;
                    task.Wait()
                }
                else
                {
                    base.OnInvoke();
                }
            }
        }
     }
