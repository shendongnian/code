        public static Activity CreateNew(Flowchart flowchart)
        {
            var inProperty = new DynamicActivityProperty
            {
                Name = "DataObject",
                Type = typeof(InOutArgument<DataObject>)
            };
            var ex = new DelegateInArgument<Exception> { Name = "exception" };
            var tryCatch = new TryCatch();
            var tryCatchException = new Catch<Exception>()
            {
                Action = new ActivityAction<Exception>()
                {
                    Argument = ex,
                    Handler =
                    new Sequence
                    {
                        Activities =
                        {
                            new Assign<Exception>
                            {
                                To = new VisualBasicReference<Exception>() 
                                {ExpressionText = "DataObject.Exception"},
                                Value = new InArgument<Exception>(ex)
                            },
                            new WriteLine()
                            {
                                Text = new InArgument<string>(new VisualBasicValue<string>() 
                               { ExpressionText = "DataObject.Exception.Message"})
                            }
                        }
                    }
                }
            };
            var activity = new DynamicActivity()
            {
                Implementation = () => new Flowchart
                {
                    StartNode = new FlowStep
                    {
                        Action = tryCatch
                    }
                },
                Properties = { inProperty }
            };
            tryCatch.Try = flowchart;
            tryCatch.Catches.Add(tryCatchException);
            AddVbSetting(activity);
            return activity;
        }
 
