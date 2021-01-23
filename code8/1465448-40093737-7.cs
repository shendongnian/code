    namespace HollowEarth.AttachedProperties
    {
        public static class TextProperties
        {
            #region TextProperties.XAMLText Attached Property
            public static String GetXAMLText(TextBlock obj)
            {
                return (String)obj.GetValue(XAMLTextProperty);
            }
            public static void SetXAMLText(TextBlock obj, String value)
            {
                obj.SetValue(XAMLTextProperty, value);
            }
            /// <summary>
            /// Convert raw string into formatted text in a TextBlock: 
            /// 
            /// @"This <Bold>is a test <Italic>of the</Italic></Bold> text."
            /// 
            /// Text will be parsed as XAML TextBlock content. 
            /// 
            /// See WPF TextBlock documentation for full formatting. It supports spans and all kinds of things. 
            /// 
            /// </summary>
            public static readonly DependencyProperty XAMLTextProperty =
                DependencyProperty.RegisterAttached("XAMLText", typeof(String), typeof(TextProperties),
                                                    new PropertyMetadata("", XAMLText_PropertyChanged));
            //  I don't recall why this was necessary; maybe it wasn't. 
            public static Stream GetStream(String s)
            {
                MemoryStream stream = new MemoryStream();
                StreamWriter writer = new StreamWriter(stream);
                writer.Write(s);
                writer.Flush();
                stream.Position = 0;
                return stream;
            }
            private static void XAMLText_PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                if (d is TextBlock)
                {
                    var ctl = d as TextBlock;
                    try
                    {
                        //  XAML needs a containing tag with a default namespace. We're parsing 
                        //  TextBlock content, so make the parent a TextBlock to keep the schema happy. 
                        //  TODO: If you want any content not in the default schema, you're out of luck. 
                        var strText = String.Format(@"<TextBlock xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation"">{0}</TextBlock>", e.NewValue);
                        TextBlock parsedContent = System.Windows.Markup.XamlReader.Load(GetStream(strText)) as TextBlock;
                        //  The Inlines collection contains the structured XAML content of a TextBlock
                        ctl.Inlines.Clear();
                        //  UI elements are removed from the source collection when the new parent 
                        //  acquires them, so pass in a copy of the collection to iterate over. 
                        ctl.Inlines.AddRange(parsedContent.Inlines.ToList());
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Trace.WriteLine(String.Format("Error in HollowEarth.AttachedProperties.TextProperties.XAMLText_PropertyChanged: {0}", ex.Message));
                        throw;
                    }
                }
            }
            #endregion TextProperties.XAMLText Attached Property
        }
    }
