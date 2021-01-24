        public class Answer
        {
            // just a sugar to represent empty responses
            public static Answer Empty { get; } = new Answer { Value = true, HasAnswered = true };
    
            public Answer()
            {
    
            }
            
            // one more time abusing from TaskCompletionSource<object>, because with this guy we are abble to send the result from the process to the user
            public Answer(TaskCompletionSource<object> completedTask)
            {
                CompletedTask = completedTask;
            }
    
            private TaskCompletionSource<object> CompletedTask { get; set; }
    
            public bool Value { get; set; }
            public bool HasAnswered { get; set; }
            
            // this method as you can see, will set the result and release the task for the user
            public void UserResponse(object response)
            {
                CompletedTask.SetResult(response);
            }
        }
