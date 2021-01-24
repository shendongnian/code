    namespace LegacyApp.Models
    {
        using System;
        using System.Collections.Generic;
    
        public partial class B : A
        {
            /// <summary>
            /// Used to assign all members of base class A to B
            /// </summary>
            /// <param name="baseClass">the base class</param>
            public B(A baseClass) : base()
            {
                foreach (var prop in typeof(A).GetProperties())
                {
                    this.GetType().GetProperty(prop.Name).SetValue(this, prop.GetValue(baseClass, null), null);
                }
            }
            public int? ID { get; set; }
        }
    }
