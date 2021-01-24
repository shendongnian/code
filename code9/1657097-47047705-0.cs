        ...
        string topicString = "NEWS/SPORTS/CRICKET";
        string subscriptionName = "NEWS.SPORTS.CRICKET";
        string topicName = "NEWS.SPORTS.CRICKET";
        MQDestination unmanagedDest = mqQueueManager.AccessQueue("SportsQ", MQC.MQOO_INPUT_EXCLUSIVE | MQC.MQOO_FAIL_IF_QUIESCING);
        int openOptionsForGet = MQC.MQSO_CREATE | MQC.MQSO_FAIL_IF_QUIESCING | MQC.MQSO_DURABLE | MQC.MQSO_RESUME;
        // MQTopic destForGet = mqQueueManager.AccessTopic(topicName, null, openOptionsForGet, null, subscriptionName);  // Hangs in "Get()"
        // MQTopic destForGet = mqQueueManager.AccessTopic(topicName, null, MQC.MQTOPIC_OPEN_AS_SUBSCRIPTION, openOptionsForGet);  // MQRC_SUB_NAME_ERROR
        // MQTopic destForGet = mqQueueManager.AccessTopic(topicName, topicString, MQC.MQTOPIC_OPEN_AS_SUBSCRIPTION, openOptionsForGet);  // MQRC_SUB_NAME_ERROR
        // MQTopic destForGet = mqQueueManager.AccessTopic(topicName, topicString, openOptionsForGet, null, subscriptionName);  // Hangs in "Get()"
        // MQTopic destForGet = mqQueueManager.AccessTopic(topicName, "SportsQ", openOptionsForGet, null, subscriptionName);  // Hangs
        // MQTopic destForGet = mqQueueManager.AccessTopic(topicName, "SportsQ", MQC.MQTOPIC_OPEN_AS_SUBSCRIPTION, openOptionsForGet);  //  MQRC_SUB_NAME_ERROR
        // MQTopic destForGet = mqQueueManager.AccessTopic(unmanagedDest, topicName, null, openOptionsForGet);  // MQRC_SUB_NAME_ERROR
        MQTopic destForGet = mqQueueManager.AccessTopic(unmanagedDest, topicName, null, openOptionsForGet, null, subscriptionName);  // <-- this works!
        MQMessage messageForGet = new MQMessage();
        MQGetMessageOptions gmo = new MQGetMessageOptions();
        gmo.Options |= MQC.MQGMO_WAIT | MQC.MQGMO_FAIL_IF_QUIESCING;
        gmo.WaitInterval = 1000;  // wait 60 seconds
        destForGet.Get(messageForGet, gmo);  // <-- No hang, if message present
        string msg = messageForGet.ReadLine();
        ...
