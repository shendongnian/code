         private bool IsEnabled1 { get; set; }
         private string IsCharBasedEnabled { get; set; }
         [NotMapped]
         public bool IsEnabled
         {
             get { return IsCharBasedEnabled == "True" || IsCharBasedEnabled == "Y" || IsEnabled1; }
             set {
                 if (value.ToString() == "Y" || value.ToString() == "N")
                 {
                     IsCharBasedEnabled = value ? "Y" : "N";
                 }
                 else if (value.ToString() == "True" || value.ToString() == "False")
                 {
                     IsCharBasedEnabled = value ? "True" : "False";
                 }
                 else if(value)
                 {
                     IsEnabled1 = true;
                 }
             }
         }
