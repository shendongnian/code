    /// <summary>
    /// This class contains extensions methods for the <see cref="MessageSender"/> class.
    /// </summary>
    public static class MessageSenderExtensions
    {
        private const string BrokeredMessageListCannotBeNullOrEmpty = "The brokeredMessageEnumerable parameter cannot be null or empty.";
        private const string SendPartitionedBatchFormat = "[MessageSender.SendPartitionedBatch] Batch Sent: BatchSizeInBytes=[{0}] MessageCount=[{1}]";
        private const string SendPartitionedBatchAsyncFormat = "[MessageSender.SendPartitionedBatchAsync] Batch Sent: BatchSizeInBytes=[{0}] MessageCount=[{1}]";
        private const int MaxBathSizeInBytes = 262144;
        /// <summary>
        /// Sends a set of brokered messages (for batch processing). 
        /// If the batch size is greater than the maximum batch size, 
        /// the method partitions the original batch into multiple batches, 
        /// each smaller in size than the maximum batch size.
        /// </summary>
        /// <param name="messageSender">The current <see cref="MessageSender"/> object.</param>
        /// <param name="messages">The collection of brokered messages to send.</param>
        /// <param name="trace">true to cause a message to be written; otherwise, false.</param>
        /// <returns>The asynchronous operation.</returns>
        public async static Task SendPartitionedBatchAsync(this MessageSender messageSender, IEnumerable<BrokeredMessage> messages, bool trace = false)
        {
            var brokeredMessageList = messages as IList<BrokeredMessage> ?? messages.ToList();
            if (messages == null || !brokeredMessageList.Any())
            {
                throw new ArgumentNullException(BrokeredMessageListCannotBeNullOrEmpty);
            }
            var batchList = new List<BrokeredMessage>();
            long batchSize = 0;
            foreach (var brokeredMessage in brokeredMessageList)
            {
                // Hack because the size of the brokered message does not take into account the size of the properties
                var messageSize = GetObjectSize(brokeredMessage.Properties) + brokeredMessage.Size;
                if ((batchSize + messageSize) > MaxBathSizeInBytes)
                {
                    // Send current batch
                    await messageSender.SendBatchAsync(batchList);
                    Trace.WriteLineIf(trace, string.Format(SendPartitionedBatchAsyncFormat, batchSize, batchList.Count));
                    // Initialize a new batch
                    batchList = new List<BrokeredMessage> { brokeredMessage };
                    batchSize = messageSize;
                }
                else
                {
                    // Add the BrokeredMessage to the current batch
                    batchList.Add(brokeredMessage);
                    batchSize += messageSize;
                }
            }
            // The final batch is sent outside of the loop
            await messageSender.SendBatchAsync(batchList);
            Trace.WriteLineIf(trace, string.Format(SendPartitionedBatchAsyncFormat, batchSize, batchList.Count));
        }
        /// <summary>
        /// Calculates the lenght in bytes of an object and returns the size.
        /// </summary>
        private static int GetObjectSize(object objectToTest)
        {
            var bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, objectToTest);
                return ms.ToArray().Length;
            }
        }
    }
