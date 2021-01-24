    using IBM.WMQ;
    using System;
    using System.Collections;
    
    
    namespace HelloSubscribe
    {
        class Program
        {
            static void Main(string[] args)
            {
                string qmName = "QM";
                string hostName = "localhost";
                string strPort = "1420";
                string channelName = "SYSTEM.DEF.SVRCONN";
                string transport = MQC.TRANSPORT_MQSERIES_CLIENT;
    
                Hashtable connectionProperties = new Hashtable();
                connectionProperties.Add(MQC.HOST_NAME_PROPERTY, hostName);
                connectionProperties.Add(MQC.PORT_PROPERTY, strPort);
                connectionProperties.Add(MQC.CHANNEL_PROPERTY, channelName);
    
                MQQueueManager mqQueueManager = new MQQueueManager(qmName, connectionProperties);
    
                string topicString = "NEWS/SPORTS/CRICKET";
                string subscriptionName = "NEWS.SPORTS.CRICKET";
                int openOptionsForGet = MQC.MQSO_FAIL_IF_QUIESCING | MQC.MQSO_DURABLE | MQC.MQSO_RESUME;
                MQTopic destForGet = mqQueueManager.AccessTopic(null, topicString, null, openOptionsForGet, null, subscriptionName);
    
                MQMessage messageForGet = new MQMessage();
                MQGetMessageOptions gmo = new MQGetMessageOptions();
                gmo.Options |= MQC.MQGMO_WAIT | MQC.MQGMO_FAIL_IF_QUIESCING;
                gmo.WaitInterval = 60000;  // wait 60 seconds
                destForGet.Get(messageForGet, gmo);
                string msg = messageForGet.ReadLine();
                System.Console.WriteLine("Received message data : " + msg);
    
                destForGet.Close();
                mqQueueManager.Disconnect();
                mqQueueManager.Close();
            }
        }
    }
