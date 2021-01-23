    namespace PostponeRadioButtonChange.Model
    {
        using System;
        using System.Collections.Generic;
    
        using Microsoft.Practices.Prism.Mvvm;
    
        public class MainWindow : BindableBase
        {
            private List<Func<bool>> rbHandlers;
    
            private string comment;
    
            public List<Func<bool>> RbHandlers
            {
                get { return this.rbHandlers; }
                private set { this.SetProperty(ref this.rbHandlers, value); }
            }
    
            public string Comment
            {
                get { return this.comment; }
                set { this.SetProperty(ref this.comment, value); }
            }
    
            public MainWindow()
            {
                this.RbHandlers = new List<Func<bool>>
                {
                    () =>
                        {
                            this.Comment = "First RadioButton clicked";
                            return false;    // Here must be your condition for checking
                        },
                    () =>
                        {
                            this.Comment = "Second RadioButton clicked";
                            return false;
                        },
                    () =>
                        {
                            this.Comment = "Third RadioButton clicked";
                            return true;   // For example, third not checked after click
                        }
                };
            }
        }
    }
