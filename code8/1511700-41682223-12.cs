     public sealed class OrderJob : IJob
     {
        public void Execute(IJobExecutionContext context)
        {
                var orderUoW = new OrderUoW();
                orderUoW.Create();
         }
      }
