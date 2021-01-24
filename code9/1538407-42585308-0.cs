        public class Process
        {
             // this dictionary store the current process running status, you will use it to define the future answer from the user interaction
             private static Dictionary<string, Answare> StatusReport = new Dictionary<string, Answare>();
             // this property is the secret to allow us wait for the ShowYesNoQuestion call, because til this happen the server doesn't send a response for the client.
             TaskCompletionSource<bool> AwaitableResult { get; } = new      TaskCompletionSource<bool>(true);
             // here we have the question to interact with the user
             IQuestionBox QuestionBox { get; set; }
             // this method, receive your bussiness logical the receive your question as a parameter
             public IQuestionBox Run(Action<IQuestionBox> action)
             {
                 QuestionBox = new QuestionBox(this);
                 // here we create a task to execute your bussiness logical processment
                 Task.Factory.StartNew(() =>
                 {
                    action(QuestionBox);
                 });
                 // and as I said we wait the result from the processment
                 Task.WaitAll(AwaitableResult.Task);
                 // and return the question box to show the messages for the users
                 return QuestionBox;
             }
             
             // this method is responsable to register a question to receive future answers, as you can see, we are using our static dictionary to register them
             public void RegisterForAnsware(string id)
             {
                if (StatusReport.ContainsKey(id))
                   return;
                StatusReport.Add(id, new Answare()
                {
                });
             }
             
             // this method will deliver an answer for this correct context based on the id
             public Answare GetAnsware(string id)
             {
                 if (!StatusReport.ContainsKey(id))
                   return Answare.Empty;
                 return StatusReport[id];
             }
             // this method Releases the processment
             public void Release()
             {
                 AwaitableResult.SetResult(true);
             }
 
             // this method end the process delivering the response for the user
             public void End(object userResponse)
             {
                if (!StatusReport.ContainsKey(QuestionBox.Id))
                   return;
                StatusReport[QuestionBox.Id].UserResponse(userResponse);
             }
             
             // this method define the answer based on the user interaction, that allows the process continuing from where it left off
             public static Task<object> DefineAnsware(string id, bool result)
             {
                 if (!StatusReport.ContainsKey(id))
                   return Task.FromResult((object)"Success on the operation");
                 // here I create a taskcompletaionsource to allow get the result of the process, and send for the user, without it would be impossible to do it
                 TaskCompletionSource<object> completedTask = new           TaskCompletionSource<object>();
                 StatusReport[id] = new Answare(completedTask)
                 {
                    HasAnswared = true,
                    Value = result
                 };
                 return completedTask.Task;
             }
        }
