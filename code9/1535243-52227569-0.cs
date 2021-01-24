            LocalPrintServer localPrintServer = new LocalPrintServer();
            // List the print server's queues
            PrintQueue pq = localPrintServer.GetPrintQueue(@"Boca FGL 200 DPI");
            PrintSystemJobInfo job = pq.AddJob();  
            System.IO.StreamWriter writer = new System.IO.StreamWriter(job.JobStream);
            writer.Write(@"hello world<p>");
            writer.Flush();
