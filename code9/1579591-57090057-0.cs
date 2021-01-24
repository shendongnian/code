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
