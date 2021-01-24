    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class RetryAttributeEx : PropertyAttribute, IWrapSetUpTearDown
    {
        private int _count;
        
        public RetryAttributeEx(int count) : base(count) {
            _count = count;
        }
        
        public TestCommand Wrap(TestCommand command) {
            return new RetryCommand(command, _count);
        }
        
        public class RetryCommand : DelegatingTestCommand {
          
            private int _retryCount;
            
            public RetryCommand(TestCommand innerCommand, int retryCount)
                : base(innerCommand) {
                _retryCount = retryCount;
            }
            
            public override TestResult Execute(TestExecutionContext context) {
              
                for (int count = _retryCount; count-- > 0; ) {
                  
                    try {
                        context.CurrentResult = innerCommand.Execute(context);
                    }
                    catch (WebDriverTimeoutException ex) {
                        if (count == 0)
                          throw;
                        continue;
                    }
                    if (context.CurrentResult.ResultState != ResultState.Failure)
                        break;
                      
                    if (count > 0)
                        context.CurrentResult = context.CurrentTest.MakeTestResult();
                }
                return context.CurrentResult;
            }
        }
        
    }
