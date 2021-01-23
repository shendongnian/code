    public class ClientActivity : Activity
    {
        TextView txt;
        protected override void OnCreate(Bundle bundle)
        {
            txt = FindViewById<TextView>(Resource.Id.textView1);
        }
        private void websocketClient_Opened(object sender, EventArgs e)
        {
            txt.Text = ("Client successfully connected."); // this line is wrong
            websocketClient.Send("Hello World!");
        }
    }
