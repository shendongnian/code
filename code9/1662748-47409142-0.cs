    using Android.App;
    using Android.Content;
    using Android.Content.Res;
    using Android.Text;
    using Android.Widget;
    using RendererTest.Droid.Renderers;
    using System;
    using System.Collections.Specialized;
    using System.Linq;
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.Android;
    [assembly: ExportRenderer(typeof(RendererTest.Controls.CustomPicker), typeof(CustomPickerRenderer))]
    namespace RendererTest.Droid.Renderers
    {
        public class CustomPickerRenderer : Xamarin.Forms.Platform.Android.AppCompat.PickerRenderer
        {
            AlertDialog _dialog;
            TextColorSwitcher _textColorSwitcher;
            public CustomPickerRenderer(Context context) : base(context) { }
            // This method is necessary to set the OnClickListener, copied removing base.OnElementChanged(e); line
            protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
            {
                if (e.OldElement != null)
                    ((INotifyCollectionChanged)e.OldElement.Items).CollectionChanged -= RowsCollectionChanged;
                if (e.NewElement != null)
                {
                    ((INotifyCollectionChanged)e.NewElement.Items).CollectionChanged += RowsCollectionChanged;
                    if (Control == null)
                    {
                        EditText textField = CreateNativeControl();
                        textField.Focusable = false;
                        textField.Clickable = true;
                        textField.Tag = this;
                        textField.InputType = InputTypes.Null;
                        textField.SetOnClickListener(PickerListener.Instance);
                        _textColorSwitcher = new TextColorSwitcher(textField.TextColors);
                        SetNativeControl(textField);
                    }
                    UpdatePicker();
                    UpdateTextColor();
                }
            }
            // This method is necessary to change negative button text.
            void OnClick()
            {
                Picker model = Element;
                if (_dialog == null)
                {
                    using (var builder = new AlertDialog.Builder(Context))
                    {
                        builder.SetTitle(model.Title ?? "");
                        string[] items = model.Items.ToArray();
                        builder.SetItems(items, (s, e) => ((IElementController)model).SetValueFromRenderer(Picker.SelectedIndexProperty, e.Which));
                        builder.SetNegativeButton("Cancel", (o, args) => { }); // Changing negative button text
                        ((IElementController)Element).SetValueFromRenderer(VisualElement.IsFocusedPropertyKey, true);
                        _dialog = builder.Create();
                    }
                    _dialog.SetCanceledOnTouchOutside(true);
                    _dialog.DismissEvent += (sender, args) =>
                    {
                        (Element as IElementController)?.SetValueFromRenderer(VisualElement.IsFocusedPropertyKey, false);
                        _dialog.Dispose();
                        _dialog = null;
                    };
                    _dialog.Show();
                }
            }
        
            void RowsCollectionChanged(object sender, EventArgs e)
            {
                UpdatePicker();
            }
            void UpdatePicker()
            {
                Control.Hint = Element.Title;
                if (Element.SelectedIndex == -1 || Element.Items == null)
                    Control.Text = null;
                else
                    Control.Text = Element.Items[Element.SelectedIndex];
            }
            void UpdateTextColor()
            {
                _textColorSwitcher?.UpdateTextColor(Control, Element.TextColor);
            }
            // The listener is changed to work with CustomPickerRenderer
            class PickerListener : Java.Lang.Object, IOnClickListener
            {
                #region Statics
                public static readonly PickerListener Instance = new PickerListener();
                #endregion
                public void OnClick(global::Android.Views.View v)
                {
                    var renderer = v.Tag as CustomPickerRenderer; // Work with my renderer
                    renderer?.OnClick();
                }
            }
        }
    }
