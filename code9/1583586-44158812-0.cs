                StackLayout TheStack = new StackLayout { HorizontalOptions = LayoutOptions.Fill, VerticalOptions = LayoutOptions.Fill, HeightRequest = 425, ClassId = ListProduct[CurrentProd].Sku.ToString(), ClassId = "Something" };
                TheStack.Children.Add(PictureProduct);
                TheStack.Children.Add(BrandName);
                TheStack.Children.Add(Description);
                TheStack.Children.Add(Price);
                var MyTapGesture = new TapGestureRecognizer();
                MyTapGesture.Tapped += (sender, e) =>
                {
                    StackLayout TappedStackId = sender as StackLayout;
                    Debug.Write("TappedStackId = " + TappedStackId.ClassId);
                };
                TheStack.GestureRecognizers.Add(MyTapGesture);
