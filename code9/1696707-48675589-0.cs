    public class SomeAction : ISomeAction
    {
        public Task<String> SomeTaskAsync()
        {
            return Task.FromResult( this.SomeMethod() );
        }
        private String SomeMethod()
        {
            String value = new TaskClass().CallThirdParty();
            return value;
        }
    }
    public class TaskClass
    {
        private class CallbackContainer : IThirdPartyDefinedCallback
        {
            public String ReturnedValue;
            public void OnSuccess(String p)
            {
                this.ReturnedValue = p;
            }
        }
        public String CallThirdParty()
        {
            ThirdParty tp = new ThirdParty();
            var somePayload = "payload";
            
            CallbackContainer callbackContainer = new CallbackContainer();
            
            tp.VoidMethodWithCallback( somePayload, callbackContainer );
            return callbackContainer.ReturnedValue;
        }
    }
