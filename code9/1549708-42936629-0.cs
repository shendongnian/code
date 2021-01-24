        var dead-letterReceiver = await receiverFactory.CreateMessageReceiverAsync(
                QueueClient.FormatDeadLetterPath(queueName), ReceiveMode.PeekLock);
        while (true)
        {
            var msg = await dead-letterReceiver.ReceiveAsync(TimeSpan.Zero);
            if (msg != null)
            {
                foreach (var prop in msg.Properties)
                {
                    Console.WriteLine("{0}={1}", prop.Key, prop.Value);
                }
                await msg.CompleteAsync();
            }
            else
            {
                break;
            }
        }
    }
