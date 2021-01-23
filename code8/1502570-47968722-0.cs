    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    using Xamarin.Forms;
    /*
    this class will help you to have bindable children with different sizes for the stacklayout with scrollview 
    in you xaml add 
        <UIControls:SAStackLayout ItemsSource="{Binding YourDataSource}"  Orientation="Horizontal">
                                <DataTemplate>
                                    <Grid>
                                        <Label Text="{Binding Name}" Margin="15,0" HorizontalOptions="Center" VerticalOptions="Center"    FontSize="Small"  VerticalTextAlignment="Center" HorizontalTextAlignment="Center" TextColor="White"/>
                                    </Grid>
                                </DataTemplate>
       </UIControls:SAStackLayout>
    
     */
    namespace Shop.UI.Controls
    {
        [ContentProperty("ItemContent")]
        public class SAStackLayout : ContentView
        {
            private ScrollView _scrollview;
            private StackLayout _stacklayout { get; set; }
            public SAStackLayout()
            {
                _stacklayout = new StackLayout();
                _scrollview = new ScrollView()
                {
                    Content = _stacklayout
                };
                Content = _scrollview;
            }
            public static readonly BindableProperty ItemContentProperty = BindableProperty.Create("ItemContent", typeof(DataTemplate), typeof(SAStackLayout), default(ElementTemplate));
    
            public DataTemplate ItemContent
            {
                get { return (DataTemplate)GetValue(ItemContentProperty); }
                set { SetValue(ItemContentProperty, value); }
            }
    
    
            private ScrollOrientation _scrollOrientation;
            public ScrollOrientation Orientation
            {
                get
                {
                    return _scrollOrientation;
                }
                set
                {
                    _scrollOrientation = value;
                    _stacklayout.Orientation = value == ScrollOrientation.Horizontal ? StackOrientation.Horizontal : StackOrientation.Vertical;
                    _scrollview.Orientation = value;
                }
            }
    
            public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create("ItemsSource", typeof(IEnumerable), typeof(SAStackLayout), default(IEnumerable), propertyChanged: GetEnumerator);
            public IEnumerable ItemsSource
            {
                get { return (IEnumerable)GetValue(ItemsSourceProperty); }
                set { SetValue(ItemsSourceProperty, value); }
            }
    
            private static void GetEnumerator(BindableObject bindable, object oldValue, object newValue)
            {
                foreach (object child in (newValue as IEnumerable))
                {
                    View view = (View)(bindable as SAStackLayout).ItemContent.CreateContent();
                    view.BindingContext = child;
                    (bindable as SAStackLayout)._stacklayout.Children.Add(view);
                }
            }
        }
    }
