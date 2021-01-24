        public void Download(ReportProgressDelegate reportProgress)
        {
            // FirstLoop
            for(int i=0; i < 100; i++)
            {
                // Do some work with GetLinks
                // this will call the backgroundworker ReportProgress method.
                reportProgress(i);
            }
        }
