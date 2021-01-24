    Using System.Printing
    
     var pri = new PrintServer();
                var queues = pri.GetPrintQueues(new[] { EnumeratedPrintQueueTypes.Local, EnumeratedPrintQueueTypes.Connections });
                foreach (var queue in queues)
                {
                    string printerName = queue.Name;
                    string printerPort = queue.QueuePort.Name;
                 }
