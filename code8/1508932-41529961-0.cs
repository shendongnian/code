    public class Subscriber1
    {
        public Subscriber1(Button button)
        {
            button.Click += ClickHander;
        }
        private void ClickHander(object sender, EventArgs e)
        {
            // ...
        }
        public void UnSubscribe()
        {
            button.Click -= ClickHandler;
        }
    }
