    var buttons = new List<ImageButton>();
    buttons.Add(FindViewById<ImageButton>(Resource.Id.button1));
    buttons.Add(FindViewById<ImageButton>(Resource.Id.button2));
    int count = 1;
    foreach(var button in buttons) {
        button.Tag = count;
        button.Click += Button_Click;
        count++;
    }
    private void Button_Click(object sender, System.EventArgs e)
    {
        Toast.MakeText(this, "I am " + (sender as Button).Tag, ToastLength.Long).Show();
    }
