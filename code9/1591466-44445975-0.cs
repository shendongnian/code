     public class ExtendedNSView : NSView
        {
            public bool IsEnabled { get; set; }
    
            public override void MouseDown(NSEvent theEvent)
            {
                if (IsEnabled)
                {
                    base.MouseDown(theEvent);
                }
            }
        }
