    public class MainActivity : Activity
    {
        RadioGroup radioGroup;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            radioGroup = FindViewById<RadioGroup>(Resource.Id.mGroup);
            //register focus change event for every sub radio button.
            for (int i = 0; i < radioGroup.ChildCount; i++)
            {
                var child=radioGroup.GetChildAt(i);
                if (child is RadioButton)
                {
                    ((RadioButton)child).FocusChange += RadioButton_FocusChange;
                }
            }
        }
        
        private void RadioButton_FocusChange(object sender, Android.Views.View.FocusChangeEventArgs e)
        {
            //check if the radio button is the button that getting focus
            if (e.HasFocus){
                ((RadioButton)sender).Checked = true;
            }
        }
    }
