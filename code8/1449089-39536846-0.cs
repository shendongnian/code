        public Book Book
        {
            get { return (Book)GetValue(BookProperty); }
            set { SetValue(BookProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Book.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BookProperty =
            DependencyProperty.Register("Book", typeof(Book), typeof(BookView), new PropertyMetadata(null));
