    using System;
    using System.ServiceModel.Configuration;
    
    namespace KeypadIdmAdaptor
    {
        public class CustomBehaviorExtensionElement : BehaviorExtensionElement
        {
            protected override object CreateBehavior()
            {
                return new CustomBehavior();
            }
    
            public override Type BehaviorType
            {
                get { return typeof(CustomBehavior); }
            }
        }
    }
