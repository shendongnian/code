    using System;
    using System.ComponentModel;
    [TypeDescriptionProvider(typeof(MyTypeDescriptionProvider))]
    public class SampleClass:Component
    {
        [RefreshProperties(RefreshProperties.All)]
        public bool Editable { get; set; }
        string sp;
        public string StringProperty
        {
            get { return sp; }
            set
            {
                if (Editable)
                    sp = value;
            }
        }
    }
