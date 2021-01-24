    [assembly: ExportRenderer(typeof(TagEntry), typeof(TagEntryRenderer))]
    
    namespace YourNameSpace.Droid
    {
        public class TagEntryRenderer : EntryRenderer
        {
            protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
            {
                base.OnElementChanged(e);
    
                if (e.NewElement != null)
                    Control.AfterTextChanged += Control_AfterTextChanged;
    
                if (e.OldElement != null)
                    Control.AfterTextChanged -= Control_AfterTextChanged;
            }
    
            private void Control_AfterTextChanged(object sender, AfterTextChangedEventArgs e)
            {
                //detect if '@' is entered.
                if (e.Editable.LastOrDefault() == '@')
                {
                    //show a popup list for selection.
                    //I here use a simple menu for testing, you should be able to change it to your list popup.
                    PopupMenu popup = new PopupMenu(Xamarin.Forms.Forms.Context, Control);
                    popup.MenuInflater.Inflate(Resource.Menu.testmenu, popup.Menu);
                    popup.Show();
                    popup.MenuItemClick += (ss, ee) =>
                    {
                        var item = ee.Item.TitleFormatted;
                        e.Editable.Delete(e.Editable.Length() - 1, e.Editable.Length());
                        SpannableString spannable = new SpannableString("@" + item);
                        spannable.SetSpan(new ForegroundColorSpan(Android.Graphics.Color.Blue), 0, item.Length() + 1, SpanTypes.ExclusiveExclusive);
                        e.Editable.Append(spannable);
                        popup.Dismiss();
                    };
                }
            }
        }
    }
