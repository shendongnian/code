        public static Task<string> messaging_server0()
        {
            using (var messagebus1 = new TinyMessageBus("ExampleChannel"))
            {
                var taskCompletition = new TaskCompletionSource<string>();
                messagebus1.MessageReceived +=
                    (sender, e) =>
                    {
                        var ret = Encoding.UTF8.GetString(e.Message);
                        taskCompletition.TrySetResult(ret);
                    };
                return taskCompletition.Task;
            }
        }
