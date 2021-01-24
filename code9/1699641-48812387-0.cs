    class MyService : IService
    {
        public void DoWhatIWant()
        {
            this.SubObject.MyPublicMethodAsync();
        }
    }
    BackgroundJob.Enqueue<IService>( s => s.DoWhatIWant() );
