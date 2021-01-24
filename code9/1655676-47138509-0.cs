    namespace XmsBrowser
    {
        class BrowseMessages
        {
            IConnection connectionWMQ;
            IQueueBrowser queueBrowser;
        static void Main(string[] args)
        {
            BrowseMessages pgm = new BrowseMessages();
            pgm.browseMessage();
        }
        private void browseMessage()
        {
            try
            {
                XMSFactoryFactory xMSFactoryFactory = XMSFactoryFactory.GetInstance(XMSC.CT_WMQ);
                // Create WMQ Connection Factory.
                IConnectionFactory connectionFactory = xMSFactoryFactory.CreateConnectionFactory();
                connectionFactory.SetStringProperty(XMSC.WMQ_HOST_NAME, "localhost");
                connectionFactory.SetIntProperty(XMSC.WMQ_PORT, 1414);
                connectionFactory.SetStringProperty(XMSC.WMQ_CHANNEL, "QM_SVRCONN_CHANNEL");
                connectionFactory.SetIntProperty(XMSC.WMQ_CONNECTION_MODE, XMSC.WMQ_CM_CLIENT);
                connectionFactory.SetStringProperty(XMSC.WMQ_QUEUE_MANAGER, "QMDEMO");
                // Create connection.
                connectionWMQ = connectionFactory.CreateConnection();
                //connectionWMQ.ExceptionListener = new ExceptionListener(OnXMSException);
                // Create session
                ISession sessionWMQ = connectionWMQ.CreateSession(false, AcknowledgeMode.AutoAcknowledge);
                IDestination destination = sessionWMQ.CreateQueue("Q1");
          
                queueBrowser = sessionWMQ.CreateBrowser(destination);
                Thread thread = new Thread(KeepBrowsingMessaegs);
                thread.Start();
                connectionWMQ.Start();
                thread.Join();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            Console.ReadKey();
        }
        private void KeepBrowsingMessaegs()
        {
            IEnumerator queueEnumerator = queueBrowser.GetEnumerator();
            while (true)
            {
                if (queueEnumerator.MoveNext())
                {
                    ITextMessage textMessage = queueEnumerator.Current as ITextMessage;
                    if (textMessage != null)
                    {
                        System.Diagnostics.Trace.Write(textMessage);
                    }
                }else
                {
                    break;
                }
            }
           }
        }
    }
