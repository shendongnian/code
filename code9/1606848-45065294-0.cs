    public static void CheckPosition(){
        Task.Delay(10000).ContinueWith(delegate{
            // Your code here
            CheckPosition();
        });
    }
