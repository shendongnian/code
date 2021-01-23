        private DoWorkEventHandler handler;
        public EventInterceptionProxy(DoWorkEventHandler handler)
        {
            this.handler = handler;
        }
        [MyOnExceptionAspect]
        public void Intercept(object sender, DoWorkEventArgs ea)
        {
            handler?.Invoke(sender, ea);
        }
    }
    [Serializable]
    public class AddHandlerInterception : MethodInterceptionAspect
    {
        public override void OnInvoke(MethodInterceptionArgs args)
        {
            args.Arguments[0] =
                new DoWorkEventHandler(new EventInterceptionProxy((DoWorkEventHandler) args.Arguments[0]).Intercept);
            args.Proceed();
        }
    }
