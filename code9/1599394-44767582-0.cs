    class AsyncForm : Form
    {
        /* The first part of listing 15.1 simply creates the UI and hooks up an event handler for
           the button in a straightforward way */
        Label label;
        Button button;
        public AsyncForm()
        {
            label = new Label { 
                                Location = new Point(10, 20),
                                Text = "Length" 
                              };
            button = new Button {
                                    Location = new Point(10, 50),
                                    Text = "Click" 
                                };  
        
            button.Click += DisplayWebSiteLength;
            AutoSize = true;
            Controls.Add(label);
            Controls.Add(button);
        }   
    
    
        /*  When you click on the button, the text of the book’s home page is fetched
            and the label is updated to display the HTML lenght in characters */
        async void DisplayWebSiteLength(object sender, EventArgs e)
        {
            label.Text = "Fetching...";
            using (HttpClient client = new HttpClient())
            {
                string text =
                await client.GetStringAsync("http://csharpindepth.com");
                label.Text = text.Length.ToString();
            }
        }
        /*  The label is updated to display the HTML length in characters D. The
            HttpClient is also disposed appropriately, whether the operation succeeds or fails—
            something that would be all too easy to forget if you were writing similar asynchronous
            code in C# 4  */
    }
