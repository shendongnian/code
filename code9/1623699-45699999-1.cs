    interface ISender
    {
        void Send(/* the args you've got for your send function */);
    }
    class Sender : ISender
    {
        void Send(/* args */) { /* code */ }
    }
    class DummySender : ISender
    {
        void Send(/* args */)
        {
            // code to validate the unit tests of Send() are passing in correctly (and you won't have it actually send anything.)
        }
    }
