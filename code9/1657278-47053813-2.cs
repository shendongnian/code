    public class CardView : ContentView
    {
        // Your stuffs
        
        public event EventHandler MyPassButtonClickedEvent;
        
        public CardView()
        {
            // Instantiate your PassButton
            PassButton.Clicked += OnPassButtonClicked;
        }
        
        protected void OnPassButtonClicked(object sender, EventArgs args)
        {
            MyPassButtonClickedEvent?.Invoke(object, args);
        }
        
        // Your stuffs
    }
