    using System.Linq;
    using System.Collections.Generic;
    using System.Collections;
    private void sendHandler()
    {
        while (true)
        {
            if (!sendQueueActive && sendQueue.Count >= 1)
            {
                sendQueueActive = true;
                
                // MAKE A COPY FIRST
                var sendQueueCopy = sendQueue.ToList();
                
                foreach (relays relays in sendQueueCopy)
                {                        
                    dynamic result = IoLogikApiConnector.put("io/relay", relays);
                    int code = result.error.code;
                    if (code != 0)
                    {
                        _log.logErrorToApi("Cannot write to IoLogik", "Error code:" + result, _deviceID);
                        _device.logErrorToApi();
                        sendQueue.Remove(relays);
                    }
                    else
                    {
                        _device.logConnectedToApi();
                        sendQueue.Remove(relays);
                    }
                    sendQueueActive = false;
                }
            }
            else
            {
                Thread.Sleep(20);
            }
        }
    }
