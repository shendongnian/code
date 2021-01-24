    public class EventProcessor
    {
      private async Task<string> ProcessNotificationEvent(int @event)
      {
        Console.WriteLine($"Processing {@event}");
        await Task.Delay(5000);
        Console.WriteLine($"Processed {@event}");
        return @event.ToString();
      }
      public async Task Process()
      {
        foreach (var notificationEvent in GetMessages()) {
          Console.WriteLine($"Got event {notificationEvent}. Will push it");
          var result = await this.ProcessNotificationEvent(notificationEvent);
          if (result != "o")
            await DeleteMessage(result);
        }
      }
      private static IEnumerable<int> GetMessages() => Enumerable.Range(1, 5);
      private async Task DeleteMessage(string @event) => Console.WriteLine($"Deleted {@event}");
    }
