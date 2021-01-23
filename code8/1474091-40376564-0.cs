    public class ProgressEventArgs : EventArgs
    {
        public int Percentage {get;set}
    }
    public class Exporter
    {
         public static event EventHandler<ProgressEventArgs> ReportProgress
         public void Export(File file, string output, string inputFile)
         {
            for (int m = 0; m < variable.Count; m++)
            {      
              ExportoFile(varibel, output);
              ReportProgress(this, new ProgressEventArgs {Percentage = m + 1};
            }        
          }
    }
