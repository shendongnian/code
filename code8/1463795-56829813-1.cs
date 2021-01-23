    public class ExtendedWebViewRenderer : ViewRenderer<ExtendedWebView, Windows.UI.Xaml.Controls.WebView>
        {
            protected override void OnElementChanged(ElementChangedEventArgs<ExtendedWebView> e)
            {
                try
                {
                    base.OnElementChanged(e);
    
                    if (e.OldElement != null && Control != null)
                    {
                        Control.NavigationCompleted -= OnWebViewNavigationCompleted;
                    }
    
                    if (e.NewElement != null)
                    {
                        if (Control == null)
                        {
                            SetNativeControl(new Windows.UI.Xaml.Controls.WebView());
                        }
    
                        Control.NavigationCompleted += OnWebViewNavigationCompleted;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error at ExtendedWebViewRenderer OnElementChanged: " + ex.Message);
                }
            }
    
            protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                base.OnElementPropertyChanged(sender, e);
    
    		// update this based on your custom webview control and what you want it to do
                if (Element is ExtendedWebView element && e.PropertyName.Equals(nameof(ExtendedWebView.Html)) && !string.IsNullOrWhiteSpace(element.Html))
                    Control.NavigateToString(element.Html); 
            }
    
            private async void OnWebViewNavigationCompleted(WebView sender, WebViewNavigationCompletedEventArgs args)
            {
                if (!args.IsSuccess)
                    return;
    
                var heightString = await Control.InvokeScriptAsync("eval", new[] {"document.body.scrollHeight.toString()" });
                if (int.TryParse(heightString, out int height))
                {
                    Element.HeightRequest = height;
                }
    
                var widthString = await Control.InvokeScriptAsync("eval", new[] {"document.body.scrollWidth.toString()" });
                if (int.TryParse(widthString, out int width))
                {
                    Element.WidthRequest = width;
                }
            }
        }
