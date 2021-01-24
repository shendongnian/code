    public class SampleEx : TextBox
        {
            [Browsable(true)]
            [DefaultValue(typeof(bool), "true")]
            new public bool AutoSize { get; set; }
    
            public SampleEx()
                : base()
            {
                this.AutoSize = true;            
            }
        }
