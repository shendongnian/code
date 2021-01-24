    using Xamarin.Forms;
    
    namespace StackOverflowHelp
    {
        /// <summary>
        /// Custom <see cref="Grid"/> containing <see cref="Label"/> next to <see cref="Entry"/>
        /// </summary>
        public class EntryTextOneLine : Grid
        {
            /// <summary>
            /// <see cref="Style"/> for <seealso cref="_text"/>
            /// </summary>
            private static Style _textStyle = new Style(typeof(Label))
            {
                Setters =
                {
                    new Setter { Property = Label.TextColorProperty, Value = Color.Black },
                    new Setter { Property = Label.FontAttributesProperty, Value = FontAttributes.Bold },
                    new Setter { Property = HorizontalOptionsProperty, Value = LayoutOptions.FillAndExpand },
                    new Setter { Property = VerticalOptionsProperty, Value = LayoutOptions.CenterAndExpand },
                    new Setter { Property = Label.HorizontalTextAlignmentProperty, Value = TextAlignment.End }
                }
            };
            /// <summary>
            /// label next to entry
            /// </summary>
            private Label _text = new Label
            {
                Style = _textStyle
            };
            /// <summary>
            /// <see cref="Entry"/>
            /// </summary>
            private Entry _entry = new Entry
            {
                VerticalOptions   = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            
            /// <summary>
            /// <see cref="Label.Text"/> next to <see cref="_entry"/>
            /// </summary>
            public string EntryText {
                get {
                    return _text.Text;
                }
                set {
                    _text.Text = value;
                }
            }
            /// <summary>
            ///  Custom <see cref="Grid"/> containing <see cref="Label"/> next to <see cref="Entry"/>
            /// </summary>
            public EntryTextOneLine()
            {
                ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.3, GridUnitType.Star) });
                ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.7, GridUnitType.Star) });
    
                RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
                
                Children.Add(_text, 0, 0);
                Children.Add(_entry, 1, 0);
            }
        }
    }
