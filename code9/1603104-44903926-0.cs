    public class Matrix44 : Control
    {
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            Button btnOut1 = this.Template.FindName("btnOut1", this) as Button;
            if (btnOut1 != null)
                btnOut1.Click += btnIn1Click;
            //...and so on for each Button
        }
    }
