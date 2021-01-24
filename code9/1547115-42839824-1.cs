    class MyProgram
    {
        private static CustomQueue MyQueue;
        public MyProgram()
        {
            MyQueue = new CustomQueue();
            MyQueue.FirstItemInserted += ConsumeQueue;
           //Activate timer...
        }
        private static void ConsumeQueue(object sender, EventArgs e)
        {
            object item;
            while (MyQueue.Count > 0)
            {
                item = MyQueue.Dequeue();
                //Do something...
            }
        }
    }
