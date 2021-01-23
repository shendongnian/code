    public static bool HasMessages()
            {
                var _mqName = ConstantHelper.SourceQueue;
                long _totalmsg = 0;
                int countAttempts = 0;
            queueExists = false;
            while (!queueExists)
            {
                if (MessageQueue.Exists(_mqName))
                {
                    queueExists = true;
                    mq = new System.Messaging.MessageQueue(_mqName);
                    _totalmsg = MessagesCounter.GetMessageCount(mq);
                    if (_totalmsg > 0)
                    {
                        logger.Info(string.Format(" {0} messages found in the {1} Queue ", _totalmsg.ToString(), _mqName));
                    }
                    else
                    {
                        logger.Info(string.Format(" There are no messages in the {1} Queue ", _totalmsg.ToString(), _mqName));
                    }
                } 
                else
                {
                    logger.Info(string.Format("No Queue named {0} found, trying again.", _mqName));
                    countAttempts++;
                    if(countAttempts % 10 == 0)
                    {
                        logger.Info(string.Format("Still no queue found, have you checked Services that Message Queuing(Micrsoft Message Queue aka. MSMQ) is up and running"));
                    } 
                    Thread.Sleep(5000);
                }
            }
            return _totalmsg > 0; 
        }
