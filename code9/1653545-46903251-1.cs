    private string result;
    
    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
    
        // Create your application here
        SetContentView(Resource.Layout.layout1);
    
        RadioGroup group1 = FindViewById<RadioGroup>(Resource.Id.group1);
        RadioGroup group2 = FindViewById<RadioGroup>(Resource.Id.group2);
    
        Button enviar = FindViewById<Button>(Resource.Id.checkBtn);
        enviar.Click += (sender, e) =>
        {
            var itemOfGroup1 = group1.CheckedRadioButtonId;
            var itemOfGroup2 = group2.CheckedRadioButtonId;
            
            if (itemOfGroup1 != -1) //if one of the group radio is checked
            {
                var radiobtn1 = FindViewById<RadioButton>(itemOfGroup1);
                result = "group1:" + radiobtn1.Text;
            }
    
            if (itemOfGroup2 != -1)
            {
                var radiobtn2 = FindViewById<RadioButton>(itemOfGroup2);
                result = result + " group2:" + radiobtn2.Text;
            }
    
            //if there're more groups, codes are the same, for example: result = result + "group3: "+ radiaobtn3.Text;
    
            var email = new Intent(Android.Content.Intent.ActionSend);
            email.PutExtra("message", result);
            //more email relative codes goes here
        };
    }
