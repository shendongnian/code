using System.Threading.Tasks.Dataflow;
static void AddWorkToQueue()
{
  queue.Send(new Item());
}
static async void MainLoop()
{
  while (true) // may be you need some cancellation token to trigger end of processing
  {
     var item = await queue.ReceiveAsync();
     ProcessItem(item);
  }
}
