    Button generate = FindViewById<Button>(Resource.Id.generate);
    
    generate.Click += Generate_Click;
    
    private void Generate_Click(object sender, EventArgs e)
    {
       EditText inputMin = FindViewById<EditText>(Resource.Id.inputMin);
       EditText inputMax = FindViewById<EditText>(Resource.Id.inputMax);
    
       int minimum, maximum;
    		
       if(!int.TryParse(inputMin.Text, out minimum) && int.TryParse(inputMax.Text, out maximum))
       {
          Console.WriteLine("Parsing problem!");
          // return;                                <--- If you want to stop.
       }
       string minString = inputMin.Text;
       string maxString = inputMax.Text;
    
       if (String.IsNullOrEmpty(minString) || String.IsNullOrEmpty(maxString))
       {
          Toast.MakeText(this, "Enter a minimum and a maximum value", 
                         ToastLength.Long).Show();
          Console.WriteLine("check input empty");
       }
       else 
       { 
          // do this 
       }
    }
