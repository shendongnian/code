     class MessageInspectorExtension : BehaviorExtensionElement
        {
            public override Type BehaviorType
            {
                get { return typeof(MessageInspector); }
            }
    
            protected override object CreateBehavior()
            {
                return new MessageInspector();
            }
        }
