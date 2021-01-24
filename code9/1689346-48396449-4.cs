    public class ViewHolder : Java.Lang.Object
    {
        public TextView txtName { get; set; }
        public TextView txtAge { get; set; }
        public TextView txtEmail { get; set; }
        public Button button1 { get; set; }
    
        public int position { get; set; }
    
        public void ShowToast()
        {
            Toast.MakeText(Application.Context, "pos: " + position.ToString(), ToastLength.Short).Show();
        }
    }
