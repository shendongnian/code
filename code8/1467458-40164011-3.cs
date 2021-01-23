    namespace ButtonRendererDemo
    {
        public partial class ListCellAccessPage : ContentPage
        {
            MyListItem[] listItems = new MyListItem[]
            {
                new MyListItem { Name= "1" },
                new MyListItem{Name= "2" },
                new MyListItem{Name= "3" },
                new MyListItem{Name= "4" }
            };
    
            public ListCellAccessPage()
            {
                InitializeComponent();
    
                test1.Text = "List";
                ListTest.ItemsSource = listItems;
            }
    
        }
    
        class MyListItem
        {
            public string Name { get; set; }
        }
    
        class MyViewCell : ViewCell
        {
           
            protected override void OnChildAdded(Element child)
            {
                base.OnChildAdded(child);
                var label = child.FindByName<Label>("test2");
                if (label != null)
                {
                    label.PropertyChanged -= Label_PropertyChanged1;//unsubscribe in case of cell reuse
                    label.PropertyChanged += Label_PropertyChanged1;
                }
    
            private void Label_PropertyChanged1(object sender, System.ComponentModel.PropertyChangedEventArgs e)
            {
                var label = sender as Label;
                if ((label != null) && (e.PropertyName == "Text"))
                {
                    if (label.Text == "3")
                        label.FontSize = 48;
                    else
                        label.FontSize = 14;//in case of cell reuse
                }
            }       
        }
    }
