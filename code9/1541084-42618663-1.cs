    /// <summary>
        /// Sends alert as SMS 
        /// </summary>
        /// <param name="details"></param>
        /// <returns></returns>
        public static Message SendSms(DeliveryDetails details)
        {
            var messageResult = new Message();
            try
            {
                if (details?.ToNumber != null)
                {
                    var toNumberList = details.ToNumber.ToList();
                    if (toNumberList.Count > 0)
                    {
                        foreach (var toNumber in toNumberList)
                        {
                            messageResult = Twilio.SendMessage(FromNumber, toNumber, $"{details.Subject}\n\n{details.Message}");
                            if (messageResult == null)
                            {
                                logger.Error(string.Format(
                                    "Error connecting to Twilio, message sending failed to {0}",
                                    toNumber));
                            }
                            else if (messageResult.RestException != null)
                            {
                                logger.Error(string.Format("Twilio Error Message Description - {0}",
                                    messageResult.RestException.Message));
                            }
                            else
                            {
                                logger.Info(String.Format("SMS {0} deliverd to {1}", messageResult.Body, messageResult.To));
                            }
                        }
                    }
                    else
                    {
                        logger.Error("ToNumber List Empty");
                    }
                }
                else
                {
                    logger.Error("ToNumber List Null");
                }
            }
            catch (Exception e)
            {
                logger.Error(String.Format("An error occurred while sending the message\n{0}", e.Message));
            }
            return messageResult;
        }
