    using CoreGraphics;
    using System;
    using UIKit;
    
    namespace MyApp.Controls
    {
        partial class Control_UpperLabel : UILabel
        {
            public Control_UpperLabel IntPtr handle) : base(handle)
            {
                   //
            }
    
            public Control_UpperLabel()
            {
                   //
            }
    
            public override void Draw(CGRect rect)
            {
                base.Draw(rect);
            }
    
            public override string Text { get => base.Text.ToUpper(); set => base.Text = value.ToUpper(); }    
       }
    }
