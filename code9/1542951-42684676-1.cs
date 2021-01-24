        // Handle mouse down events on listbox items
        private void listBoxItems_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Ideally, i'd like to do something like this
            Item item = (sender as ListBoxItem).DataContext as Item;
            // So then I could do for example
            Console.WriteLine(@"Clicked item SomeString: {0}, SomeInt {1}", item.SomeString, item.SomeInt);
        }
