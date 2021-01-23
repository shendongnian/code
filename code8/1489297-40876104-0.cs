    namespace Microsoft.Samples.PowerShell.Commands
    {
      using System;
      using System.Diagnostics;
      using System.Management.Automation;           // Windows PowerShell namespace
      #region GetProcCommand
    
      /// <summary>
      /// This class implements the get-proc cmdlet.
      /// </summary>
      [Cmdlet(VerbsCommon.Get, "Proc")]
      public class GetProcCommand : Cmdlet
      {
        #region Parameters
    
        /// <summary>
        /// The names of the processes retrieved by the cmdlet.
        /// </summary>
        private string[] processNames;
    
        /// <summary>
        /// Gets or sets the names of the 
        /// process that the cmdlet will retrieve. 
        /// </summary>
        [Parameter(
                   Position = 0,
                   ValueFromPipeline = true,
                   ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string[] Name
        {
          get { return this.processNames; }
          set { this.processNames = value; }
        }
    
        #endregion Parameters
    
        #region Cmdlet Overrides
    
        /// <summary>
        /// The ProcessRecord method calls the Process.GetProcesses 
        /// method to retrieve the processes specified by the Name 
        /// parameter. Then, the WriteObject method writes the 
        /// associated processes to the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {        
          // If no process names are passed to the cmdlet, get all 
          // processes.
          if (this.processNames == null)
          {
            WriteObject(Process.GetProcesses(), true);
          }
          else
          {
            // If process names are passed to the cmdlet, get and write 
            // the associated processes.
            foreach (string name in this.processNames)
            {
              WriteObject(Process.GetProcessesByName(name), true);
            }
          } // End if (processNames ...)
        } // End ProcessRecord.
    
        #endregion Overrides
      } // End GetProcCommand.
      #endregion GetProcCommand
    }
