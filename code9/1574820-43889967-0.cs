    class MyActor : ReceiveActor
    {
        private readonly ICancelable cancelTimer;
        public MyActor()
        {
            var interval = TimeSpan.FromSeconds(1);
            cancelTimer = Context.System.Scheduler
                .ScheduleTellRepeatedlyCancelable(interval, interval, Self, new SomeMessage(), ActorRefs.NoSender);
        }
        protected override void PostStop()
        {
            cancelTimer.Cancel();
            base.PostStop();
        }
    }
