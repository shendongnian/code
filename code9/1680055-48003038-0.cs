    public class MyPickerRenderer : PickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            if(e.OldElement != null)
            {
                var toolbar = (UIToolbar)Control.InputAccessoryView;
                var doneBtn = toolbar.Items[1];
                doneBtn.Clicked -= DoneBtn_Clicked;
            }
            if(e.NewElement != null)
            {
                var toolbar = (UIToolbar)Control.InputAccessoryView;
                var doneBtn = toolbar.Items[1];
                doneBtn.Clicked += DoneBtn_Clicked;
            }
        }
        void DoneBtn_Clicked(object sender, EventArgs e)
        {
            Console.WriteLine("Clicked!!!!");
        }
    }
