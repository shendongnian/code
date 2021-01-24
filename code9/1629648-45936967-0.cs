    using CoreGraphics;
    using System;
    using UIKit;
    
    namespace MyApp.Controls
    {
        partial class Control_InfoLabel : UILabel
        {
            public Control_InfoLabel(IntPtr handle) : base(handle)
            {
    
            }
    
            public Control_InfoLabel()
            {
    
            }
    
            public override void Draw(CGRect rect)
            {
                base.Draw(rect);
            }
    
                    public override string Text { get => base.Text.ToUpper(); set => base.Text = value.ToUpper(); }    }
    }
