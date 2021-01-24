    public class InsertBulkRecordsTask
    {
        private ConcurrentQueue<Contact> _contactsQueue;
        public void Execute()
        {
            try
            {
                var contacts = RetrieveContactsFromStaticML(ConnectToCrm(), marketingListRecord);
                _contactsQueue = new ConcurrentQueue<Contact>(contacts);
                var threadsCount = AppConfigReader.ThreadsCount;
                var threads = new List<Thread>();
                for (int i = 0; i < threadsCount; i++)
                    threads.Add(new Thread(ProcessContactsQueue) { IsBackground = true });
                threads.ForEach(r => r.Start());
                threads.ForEach(r => r.Join());
            }
            catch (Exception ex)
            {
                // TODO: log
            }
        }
        private void ProcessContactsQueue()
        {
            try
            {
                while (_contactsQueue.IsEmpty == false)
                {
                    Contact contact;
                    if (_contactsQueue.TryDequeue(out contact) && contact != null)
                    {
                        try
                        {
                            // Save contact
                        }
                        catch (Exception ex)
                        {
                            // TODO: log
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // TODO: log
            }
        }
    }
