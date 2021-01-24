    public partial class Form1 : Form
    {
        int minutes;
        int second;
        public void Mins_TextChanged(object sender, EventArgs e)
		{
			minutes = Convert.ToInt32(Mins.Text);
		}
		public void Seconds_TextChanged(object sender, EventArgs e)
		{
			second = Convert.ToInt32(Seconds.Text);
		}
	}
