        /// <summary>
        /// This method is meant as an eventhandler to be called when the Console received a cancel signal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void OnConsoleCancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            //Got Ctrl+C from console
            Console.WriteLine("Shutting down.");
            CancelTokenSource.Cancel();
        }
