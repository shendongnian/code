    public partial class UserView : UserControl
        {
    
    
    
            public ObservableCollection<User> UserViewCollection
            {
                get { return (ObservableCollection<User>)GetValue(UserViewCollectionProperty); }
                set { SetValue(UserViewCollectionProperty, value); }
            }
    
            // Using a DependencyProperty as the backing store for UserViewCollection.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty UserViewCollectionProperty =
                DependencyProperty.Register("UserViewCollection", typeof(ObservableCollection<User>), typeof(UserView), new PropertyMetadata(null, OnCollectionChanged));
    
    
    
            private static OnCollectionChanged(DependencyObject d,  DependencyPropertyChangedEventArgs args)
            {
                UserView self = d as UserView;
    
                if(self != null)
                {
                    self.UpdateButtonsInCodeBehind(args.NewValue as ObservableCollection<User>);
                }
            }
    
    
    
            public UserView(IEnumerable<User> usersFromDb)
            {
    
                InitializeComponent();
               
            }
    
    
            private void UpdateButtonsInCodeBehind(ObservableCollection<User> collection)
            {
                if(collection != null)
                {
                    UserGrid.Children.Clear();
                    var spacer = 0;
                    foreach (var user in collection)
                    {
                        var canvas = new Canvas
                        {
                            Width = 1080,
                            Height = 70
                        };
    
                        var canavasThickness = canvas.Margin;
                        canavasThickness.Top = spacer;
                        canvas.Margin = canavasThickness;
                        canvas.VerticalAlignment = VerticalAlignment.Top; // <------ THIS IS THE SOLUTION <-------- //
                        UserGrid.Children.Add(canvas);
    
                        var button = new Button
                        {
                            Width = 1080,
                            Height = 70,
                            FontSize = 20,
                            Content = $"{user.Name} {user.Surname}",
                            Background = Brushes.Azure,
                            Foreground = Brushes.Black
                        };
    
                        canvas.Children.Add(button);
    
                        spacer += 150;
                    }
                }
            }
        }
