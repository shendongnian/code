    			var queueMessage = new MQMessage();  <--- i want to do this new once!
    			while (true) {
    				//var queueMessage = new MQMessage(); // <-- only works if I do this every time i do a get
    				queueMessage.ClearMessage(); //Try this
                    queueMessage.MessageId = MQC.MQMI_NONE;
                    queueMessage.CorrelationId = MQC.MQCI_NONE; 
    				get.Get(queueMessage, gmo);
