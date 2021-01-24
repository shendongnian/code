    public class ItemTemplateViewCell : ViewCell
    {
        Label nameLbl;
        StackLayout sLayout;
        Button btnViewcell;
        public ItemTemplateViewCell()
        {
            nameLbl = new Label()
            sLayout = new StackLayout ()
            btnViewcell = new Button {Text = "Show class details"};
            NameLbl.SetBinding(Label.TextProperty, "Name");
            sLayout.Children.Add(NameLbl);
            btnViewcell.Clicked += OnButtonClicked;
            sLayout.Children.Add(btnViewcell);
            this.View = sLayout;
        }
        
        void OnButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Home()); 
        }
    }
