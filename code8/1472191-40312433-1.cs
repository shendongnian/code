        private static NLog.Logger PDlogger = NLog.LogManager.GetLogger("PaymentDetailsLogger");
		
        /// <summary>
        /// Logs an information message using NLOG
        /// </summary>
        /// <param name="message">The message to be logged</param>
        public static void LogInfo(string message)
        {
            PDlogger.Info(message);
        }
