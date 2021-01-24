lang-cs
[FunctionName("SOExampleFunction"]
public static async Task ProcessMessage(
    [ServiceBusTrigger("myqueue")] Message message,
    MessageReceiver messageReceiver)
{
    . . .
    await messageReceiver.DeadLetterAsync(message.SystemProperties.LockToken);
    . . .
}
While using this approach, make sure you have the "autoComplete" service bus setting set to false in your host.json. E.g.:
json
{
  "version": "2.0",
  "extensions": {
    "serviceBus": {
      "messageHandlerOptions": {
        "autoComplete": false
      }
    }
  }
}
