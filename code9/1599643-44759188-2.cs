    public class Library
        {
            private TextBlock myTb{ get; set; }
            public Library()
            {
                myTb = MainPage.mainPage.TextBlockName;
            }
            public void Doit()
            {
                myTb.Text = "there";
            }
    
        }
