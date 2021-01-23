    using System.Collections.ObjectModel;
    using Xamarin.Forms;
    
    public Page1()
    {
       InitializeComponent();
    
       ObservableCollection<Element> Elements = new ObservableCollection<Element>();
    
       ELementView.ItemsSource = Elements;
       Elements.Add(new Element { Name = "oooo" });
    }
