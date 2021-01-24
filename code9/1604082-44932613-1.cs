    [assembly: ExportRenderer(typeof(AutofillTextView), typeof(AutofillTextViewRenderer))]
    
    namespace Default
    {
        public class AutofillTextViewRenderer : ViewRenderer<AutofillTextView, InstantAutoCompleteTextView>
        {
            protected override void OnElementChanged(ElementChangedEventArgs<AutofillTextView> e)
            {
                base.OnElementChanged(e);
    
                if (Control == null)
                {
                    var control = new InstantAutoCompleteTextView(Forms.Context);
    
                    control.InputType = Android.Text.InputTypes.ClassText | Android.Text.InputTypes.TextFlagNoSuggestions;
                    control.Text = Element.Text;
                    SetNativeControl(control);
                }
    
                if (e.OldElement != null)
                {
                    
                }
    
                if (e.NewElement != null)
                {
                    var adapter = new ArrayAdapter<string>(Forms.Context as Android.App.Activity, Resource.Layout.AutofillTextViewItem, e.NewElement.Items.ToArray<string>());
                    Control.Adapter = adapter;
                    Control.Threshold = 0;
                    Control.TextChanged += Control_TextChanged;
                    adapter.NotifyDataSetChanged();
                }
            }
    
            void Control_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
            {
                if (Element.Text != Control.Text)
                {
                    Element.Text = Control.Text;
                }
            }
    
            protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                base.OnElementPropertyChanged(sender, e);
                if (e.PropertyName == AutofillTextView.ItemsProperty.PropertyName)
                {
                    var adapter = new ArrayAdapter<string>(Forms.Context as Android.App.Activity, Resource.Layout.AutofillTextViewItem, Element.Items.ToArray<string>());
                    Control.Adapter = adapter;
                    adapter.NotifyDataSetChanged();
                } 
                else if(e.PropertyName == AutofillTextView.TextProperty.PropertyName)
                {
                    if(Control.Text != Element.Text)
                    {
                        Control.Text = Element.Text;
                    }
                } else if(e.PropertyName == AutofillTextView.IsFocusedProperty.PropertyName) {
                    if(Element.IsFocused)
                        Control.PerformFiltering();
                }
            }
    
            
        }
    }
