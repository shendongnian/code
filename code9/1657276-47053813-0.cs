    public class CardView : ContentView
    {
        // Your stuffs
        public void AddPassButtonClickedEvent(EventHandler handler)
        {
            if(handler != null)
                PassButton.Clicked += handler;
        }
        
        // Your stuffs
    }
