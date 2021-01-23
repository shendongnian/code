    class Counter
    {
        public event EventHandler DetailsButtonClicked;
        protected virtual void OnDetailsButtonClicked(EventArgs e)
        {
            if (DetailsButtonClicked != null)
            {
                DetailsButtonClicked(this, e);
            }
        }
        // provide remaining implementation for the class
    }
