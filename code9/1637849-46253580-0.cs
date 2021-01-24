    class SomeClass {
        static void Func() {
            var Content = new Label();
            #if __IOS__
                Padding = new Thickness(1,2,3,4);
            #endif
        }
    }
