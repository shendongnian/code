    [assembly: ExportRenderer(typeof(MyTabbedPage), typeof(MyTabbedPageRenderer))]
    
    namespace YOURNAMESPACE.Droid
    {
        public class MyTabbedPageRenderer : TabbedPageRenderer
        {
            private ObservableCollection<Xamarin.Forms.Element> children;
            private IPageController controller;
    
            protected override void SetTabIcon(TabLayout.Tab tab, FileImageSource icon)
            {
                base.SetTabIcon(tab, icon);
    
                tab.SetCustomView(Resource.Layout.mytablayout);
    
                var imagebtn = tab.CustomView.FindViewById<ImageButton>(Resource.Id.closebtn);
                imagebtn.SetBackgroundDrawable(tab.Icon);
    
                var title = tab.CustomView.FindViewById<TextView>(Resource.Id.tabtitle);
                title.Text = tab.Text;
    
                imagebtn.Click += (sender, e) =>
                {
                    var closebtn = sender as ImageButton;
                    var parent = closebtn.Parent as Android.Widget.RelativeLayout;
                    var closingtitle = parent.FindViewById<TextView>(Resource.Id.tabtitle);
                    foreach (var child in children)
                    {
                        var page = child as ContentPage;
                        if (page.Title == closingtitle.Text)
                        {
                            children.Remove(child);
                            break;
                        }
                    }
                };
            }
    
            protected override void OnElementChanged(ElementChangedEventArgs<TabbedPage> e)
            {
                base.OnElementChanged(e);
                if (e.NewElement != null)
                {
                    controller = Element as IPageController;
                    children = controller.InternalChildren;
                }
            }
        }
    }
