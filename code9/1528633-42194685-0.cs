    protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            var extendedPicker = e.NewElement as ExtendedPicker;
            if (extendedPicker == null) return;
            var toolbar = new UIToolbar(new CGRect(0.0f, 0.0f, Control.Frame.Size.Width, 44.0f));
            toolbar.Items = new[]
            {
                new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace),
                new UIBarButtonItem("Done",
                    UIBarButtonItemStyle.Done,
                    delegate {
                        Control.ResignFirstResponder();
                    })
            };
            if (this.Control != null)
            {
                Control.InputAccessoryView = toolbar;
            }
        }
