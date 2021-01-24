    public static ImageButton StandardImageButton ( string buttonText, EventHandler onClickedEventHandler = null, string imageResourceID = "MyApp.standardbutton.png", string imageSource = null, 
                                                  Color textColour = default(Color), string fontFamily = null, double fontSize = 15D, FontAttributes fontAttributes = FontAttributes.Bold, 
                                                  double heightRequest = 44D, double widthRequest = 200D, bool hideKeyboard = true )
        // Returns tappable image serving as a button
        // buttonText = text overlaid onbutton
        // Image is sourced from embedded PCL file (Build Action = Embedded Resource) OR, if imageSourceID is non-null, from local platform file in platform-specific location
        {
            // Background image
            Image image = new Image 
            { 
                Aspect = Aspect.Fill,           // Stretch to fill
                HeightRequest = heightRequest,
                WidthRequest = widthRequest,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            if ( imageResourceID == null )
                image.Source = ImageSource.FromFile ( imageSource );
            else
                image.Source = ImageSource.FromResource ( imageResourceID );
            // Foreground label
            Color colour;
            if ( textColour == default(Color) )
                colour = Color.Black;
            else
                colour = textColour;
            
            Label label = new Label 
            {
                Text = buttonText,
                TextColor = colour,
                FontFamily = fontFamily,
                FontSize = fontSize,
                FontAttributes = fontAttributes,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center
            };
            ImageButton ret = new ImageButton ( image, label, hideKeyboard );
            ret.Clicked += onClickedEventHandler;
            return ret;
        }
