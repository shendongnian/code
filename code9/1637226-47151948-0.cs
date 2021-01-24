    public class MyPickerRenderer : Xamarin.Forms.Platform.Android.PickerRenderer
    {
        private IElementController ElementController => Element as IElementController;
        private AlertDialog _dialog;
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement == null || e.OldElement != null)
                return;
            Control.Click += Control_Click;
        }
        protected override void Dispose(bool disposing)
        {
            Control.Click -= Control_Click;
            base.Dispose(disposing);
        }
        private void Control_Click(object sender, EventArgs e)
        {
            Picker model = Element;
            var picker = new NumberPicker(Context);
            if (model.Items != null && model.Items.Any())
            {
                picker.MaxValue = model.Items.Count - 1;
                picker.MinValue = 0;
                picker.SetDisplayedValues(model.Items.ToArray());
                picker.WrapSelectorWheel = false;
                picker.DescendantFocusability = DescendantFocusability.BlockDescendants;
                picker.Value = model.SelectedIndex;
            }
            var layout = new LinearLayout(Context) { Orientation = Orientation.Vertical };
            layout.AddView(picker);
            ElementController.SetValueFromRenderer(VisualElement.IsFocusedProperty, true);
            var builder = new AlertDialog.Builder(Context);
            builder.SetView(layout);
            builder.SetTitle(model.Title ?? "");
            builder.SetNegativeButton("Cancel =-= ", (s, a) =>
            {
                ElementController.SetValueFromRenderer(VisualElement.IsFocusedProperty, false);
                // It is possible for the Content of the Page to be changed when Focus is changed.
                // In this case, we'll lose our Control.
                Control?.ClearFocus();
                _dialog = null;
            });
            builder.SetPositiveButton("Ok 0.0", (s, a) =>
            {
                ElementController.SetValueFromRenderer(Picker.SelectedIndexProperty, picker.Value);
                // It is possible for the Content of the Page to be changed on SelectedIndexChanged.
                // In this case, the Element & Control will no longer exist.
                if (Element != null)
                {
                    if (model.Items.Count > 0 && Element.SelectedIndex >= 0)
                        Control.Text = model.Items[Element.SelectedIndex];
                    ElementController.SetValueFromRenderer(VisualElement.IsFocusedProperty, false);
                    // It is also possible for the Content of the Page to be changed when Focus is changed.
                    // In this case, we'll lose our Control.
                    Control?.ClearFocus();
                }
                _dialog = null;
            });
            _dialog = builder.Create();
            _dialog.DismissEvent += (ssender, args) =>
            {
                ElementController?.SetValueFromRenderer(VisualElement.IsFocusedProperty, false);
            };
            _dialog.Show();
        }
    }
