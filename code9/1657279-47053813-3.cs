    class Fake
    {
        CardView cardView;
        
        public Fake()
        {
            cardView = new CardView();
            cardView.MyPassButtonClickedEvent += MyHandler;
        }
        
        void MyHandler(object sender, EventArgus args)
        {
            // Do something
        }
    }
