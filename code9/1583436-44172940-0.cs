    public class PostsharpAttrAttribute : MethodInterceptionAspect
    {
        public override void OnInvoke(MethodInterceptionArgs args)
        {
           bool awaitDirectly = false;
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
