    class MyDataReceived : hcmTerminal.onDataReceived {
        public void isCompleted(bool done) {
            Console.WriteLine("call to isCompleted. done={0}", done);
        }
    }
