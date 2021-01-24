    class Emojis
    {
           // public delegate void EmojiClickEventHandler(object sender,EventArgs args);
           //public event EmojiEventHandler EmojiClicked;
           //you can use above two lines or replace them instead below code.
            public event EventHandler<EmojiClickEventArgs> EmojiClicked;
            public void CreateEmojiList()
             {
                 CreateAllEmojis();
                 int btnCount = 0;
                 //rest of the code
                panel_main.Controls.Add(btnEmoji);
                btnEmoji.Click += OnEmojiClick(btnEmoji);
                btnCount++;
            }
    
       protected virtual void OnEmojiClick(Button emoji)
       {
        //Here null check to handle if no subscribers for the event
        if(EmojiClicked!=null)
           {
               //there is no name property define for emoji but only text hence passing only text.
              EmojiClicked(this ,new  EmojiClickEventArgs(emoji.Text,emoji.Text){ });
           }
       }
       private void Emoji_Clicked(Object sender, EmojiClickEventArgs args)
            {
                Button mybutton = sender as Button;
                Console.WriteLine("emoji text "+ args.Text);
            }
}
