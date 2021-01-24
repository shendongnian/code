    using System;
    using Android.App;
    using Android.Content.Res;
    using Android.Graphics.Drawables;
    using Android.Text;
    using Android.Util;
    using IncAlert;
    using IncAlert.Droid;
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.Android;
    using Graphicss = Android.Graphics;
      [assembly: ExportRenderer(typeof(CustomDatePicker), 
      typeof(CustomDatePickerRender))]
      namespace IncAlert.Droid
      {
	   public class CustomDatePickerRender : DatePickerRenderer
	    {
		public CustomDatePickerRender(){}
		protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
		{
			base.OnElementChanged(e);
			try
			{
				CustomDatePicker element = Element as CustomDatePicker;
				if (e.NewElement != null)
				{
					element = Element as CustomDatePicker;
				}
				else
				{
					element = e.OldElement as CustomDatePicker;
				}
				if (Control != null)
				{
					//var element = Element as CustomDatePicker;
					GradientDrawable gd = new GradientDrawable();
					//gd.SetCornerRadius(45); // increase or decrease to changes the corner look
					gd.SetColor(global::Android.Graphics.Color.Transparent);
					//gd.SetStroke(2, global::Android.Graphics.Color.Gray);
					this.Control.SetBackgroundDrawable(gd);
					this.Control.SetRawInputType(InputTypes.TextFlagNoSuggestions);
					if (!string.IsNullOrWhiteSpace(element.EnterText))
					{
						Control.Text = element.EnterText;
					}
					Control.SetHintTextColor(ColorStateList.ValueOf
       (global::Android.Graphics.Color.Black));//for placeholder
					if (element.CustomFontSize != 0.0)
					{
						Control.SetTextSize(ComplexUnitType.Dip, element.CustomFontSize);
						//Control.SetTextSize(Android.Util.ComplexUnitType.Dip, element.CustomFontSize);
					}
					if (element.CustomFontFamily == "Avenir65")
					{
						Graphicss.Typeface font = Graphicss.Typeface.CreateFromAsset(Forms.Context.Assets, "AvenirLTStd-Medium.ttf");
						Control.Typeface = font;
					}
					else if (element.CustomFontFamily == "Avenir45")
					{
						Graphicss.Typeface font = Graphicss.Typeface.CreateFromAsset(Forms.Context.Assets, "AvenirLTStd-Book.ttf");
						Control.Typeface = font;
					}
					else
					{
					}
				}
			}
			catch (Exception ex)
			{
				var msg = ex.Message;
			}
			//this.Control.InputType = InputTypes.TextVariationPassword;
		}
		protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);
			try
			{
				CustomDatePicker element = Element as CustomDatePicker;
				if (Control != null)
				{
					//var element = Element as CustomDatePicker;
					GradientDrawable gd = new GradientDrawable();
					//gd.SetCornerRadius(45); // increase or decrease to changes the corner look
					gd.SetColor(global::Android.Graphics.Color.Transparent);
					//gd.SetStroke(2, global::Android.Graphics.Color.Gray);
					this.Control.SetBackgroundDrawable(gd);
					this.Control.SetRawInputType(InputTypes.TextFlagNoSuggestions);
					if (!string.IsNullOrWhiteSpace(element.EnterText))
					{
						//Control.Text = element.EnterText;
					}
					Control.SetHintTextColor(ColorStateList.ValueOf(global::Android.Graphics.Color.Black));//for placeholder
					if (element.CustomFontSize != 0.0)
					{
						Control.SetTextSize(ComplexUnitType.Dip, element.CustomFontSize);
						//Control.SetTextSize(Android.Util.ComplexUnitType.Dip, element.CustomFontSize);
					}
					if (element.CustomFontFamily == "Avenir65")
					{
						Graphicss.Typeface font = Graphicss.Typeface.CreateFromAsset(Forms.Context.Assets, "AvenirLTStd-Medium.ttf");
						Control.Typeface = font;
					}
					else if (element.CustomFontFamily == "Avenir45")
					{
						Graphicss.Typeface font = Graphicss.Typeface.CreateFromAsset(Forms.Context.Assets, "AvenirLTStd-Book.ttf");
						Control.Typeface = font;
					}
					else
					{
					}
				}
			}
			catch (Exception ex)
			{
				var msg = ex.Message;
			}
			//this.Control.InputType = InputTypes.TextVariationPassword;
		   }
	   }
    }
