    case 2: // MainPage.xaml line 13
        {                    
            global::Windows.UI.Xaml.Controls.Grid element2 = (global::Windows.UI.Xaml.Controls.Grid)target;
            MainPage_obj2_Bindings bindings = new MainPage_obj2_Bindings();
            returnValue = bindings;
            bindings.SetDataRoot(element2.DataContext);
            element2.DataContextChanged += bindings.DataContextChangedHandler;
            global::Windows.UI.Xaml.DataTemplate.SetExtensionInstance(element2, bindings);
        }
        break;
