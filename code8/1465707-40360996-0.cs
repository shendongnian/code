		using System;
		using System.Collections.Generic;
		using System.Linq;
		using System.Threading;
		using Microsoft.ServiceBus;
		using Microsoft.ServiceBus.Messaging;
		using Polly;
        private static void KeepReadingTheQueue(QueueClient qc)
        {
            int retries = 0;
            int eventualFailures = 0;
            Policy pol = Policy.Handle<System.OperationCanceledException>(ex => null != ex)
                .Or<UnauthorizedAccessException>(ex => null != ex)
                .Or<Microsoft.ServiceBus.Messaging.MessagingCommunicationException>()
                .Or<Microsoft.ServiceBus.Messaging.MessageLockLostException>()
                .WaitAndRetryForever(
                sleepDurationProvider: attempt => TimeSpan.FromMilliseconds(500), // Wait 500ms between each try.
                onRetry: (exception, calculatedWaitDuration, context) => // Capture some info for logging!
                {
                    ReportDuplicatesOrMissing("Policy.OnRetry", batchNumbers);
                    // This is your new exception handler! 
                    // Tell the user what they've won!
                    Console.WriteLine("Log, then retry: " + exception.Message, ConsoleColor.Yellow);
                    retries++;
                });
            int i = 0;
			
			int receiveBatchSize = 1; /* i have this in a custom settings class, hard coded here */
            while (true)
            {
                i++;
                ReportDuplicatesOrMissing("while.true", batchNumbers);
                try
                {
                    // Retry the following call according to the policy - 15 times.
                    pol.Execute(() =>
                    {
                        IEnumerable<BrokeredMessage> messages = null;
                        if (receiveBatchSize <= 1)
                        {
                            // Receive the message from the queue
                            BrokeredMessage receivedMessage = qc.Receive();
                            List<BrokeredMessage> listMsgs = new List<BrokeredMessage>();
                            listMsgs.Add(receivedMessage);
                            messages = listMsgs as IEnumerable<BrokeredMessage>;
                        }
                        else
                        {
                            messages = qc.ReceiveBatch(receiveBatchSize);
                            int count = messages.Count();
                            if (count > 0)
                            {
                                Console.WriteLine("ReceiveBatch.Count='{0}'", count);
                            }
                        }
                        foreach (BrokeredMessage receivedMessage in messages)
                        {
                            if (receivedMessage != null)
                            {
								MyPayLoadObject concreteMsgObject = receivedMessage.GetBody<MyPayLoadObject>();
								receivedMessage.Complete();
								Console.WriteLine(@"Message received: {0}", concreteMsgObject);
                            }
                            else
                            {
                                Console.WriteLine(@"No new messages in the queue");
                                Thread.Sleep(1000);
                            }
                            Thread.Sleep(100);
                        }
                    });
                }
                catch (Exception e)
                {
                    Console.WriteLine("Request " + i + " eventually failed with: " + e.Message, ConsoleColor.Red);
                    eventualFailures++;
                }
            }
        }
