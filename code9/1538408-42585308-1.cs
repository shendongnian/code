        public interface IQuestionBox
        {
            string Id { get; }
            Task<bool> ShowYesNoQuestionBox(string question);
            HtmlString ShowMessage();
        }
    
        class QuestionBox : IQuestionBox
        {
            Process CurrentProcess { get; set; }
    
            public string Id { get; } = Guid.NewGuid().ToString();
            private string Question { get; set; }
    
            public QuestionBox(Process currentProcess)
            {
                CurrentProcess = currentProcess;
                CurrentProcess.RegisterForAnswer(this.Id);
            }
    
            public Task<bool> ShowYesNoQuestionBox(string question)
            {
                Question = question;
                CurrentProcess.Release();
                return AwaitForAnswer();
            }
    
            public HtmlString ShowMessage()
            {
                HtmlString htm = new HtmlString(
                    $"<script>showMessage('{Question}', '{Id}');</script>"
                );
    
                return htm;
            }
    
            private Task<bool> AwaitForAnswer()
            {
                TaskCompletionSource<bool> awaitableResult = new TaskCompletionSource<bool>(true);
    
                Task.Factory.StartNew(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(2000);
                        var answare = CurrentProcess.GetAnswer(this.Id);
                        if (!answare.HasAnswered)
                            continue;
                        awaitableResult.SetResult(answare.Value);
                        break;
                    }
                });
    
                return awaitableResult.Task;
            }
        }
