        public static bool CheckStatusAfter(ZebraPrinter printer)
        {
            try
            {
                printerStatus = printer.GetCurrentStatus();
                while ((printerStatus.numberOfFormatsInReceiveBuffer > 0) && (printerStatus.isReadyToPrint))
                {
                    Thread.Sleep(500);
                    printerStatus = printer.GetCurrentStatus();
                }
            }
            catch (ConnectionException e)
            {
                Console.WriteLine($"Error getting status from printer: {e.Message}");
            }
            if (printerStatus.isReadyToPrint)
            {
                Console.WriteLine($"Ready To Print");
                return true;
            }
            else
            {
                Console.WriteLine($"Cannot Print because the printer is in error.");
            }
            return false;
        }
