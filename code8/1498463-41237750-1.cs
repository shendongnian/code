    public class MyEditTestRenderer : ViewRenderer<MyEditText, EditText>,Android.Views.View.IOnClickListener
    {
        EditText et;
        protected override void OnElementChanged(ElementChangedEventArgs<MyEditText> e)
        {
            base.OnElementChanged(e);
            
            if (e.OldElement == null)
            {
                // perform initial setup
                et = new EditText(this.Context);
                SetNativeControl(et);
            }
            et.Click += Et_Click; 
            et.Hint = "name";
           // et.SetOnClickListener(this);
            
        }
        private void Et_Click(object sender, EventArgs e)
        {
            et.Hint = "";
        }
    }  
