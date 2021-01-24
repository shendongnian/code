    public class MyTask : Task
    {
        [Required]
        public string ConfigurationName { get; set; }
        [Required]
        public string TargetPath { get; set; }
        public override bool Execute()
        {
            var output = this.TargetPath; // TargetPath variable
            var configuration = this.ConfigurationName; // ConfigurationName variable
            RunScript(output, configuration);
            return true;
        }
    }
