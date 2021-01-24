      using System;
      using IncAlert;
      using IncAlert.iOS;
      using UIKit;
      using Xamarin.Forms;
      using Xamarin.Forms.Platform.iOS;
       [assembly: ExportRenderer(typeof(CustomDatePicker), 
      typeof(CustomDatePickerRender))]
       namespace IncAlert.iOS
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
					var textGiven = element.EnterText;
					Control.BorderStyle = UITextBorderStyle.None;
					Control.AdjustsFontSizeToFitWidth = true;
					Control.Layer.CornerRadius = 10;
					Control.ExclusiveTouch = true;
					if (!string.IsNullOrWhiteSpace(textGiven))
					{
						Control.Text = textGiven;
					}
					Control.TextColor = UIColor.Black;
					if (element.CustomFontFamily == "Avenir65")
					{
						Control.Font = UIFont.FromName("AvenirLTStd-Medium.ttf", 15f);
					}
					else if (element.CustomFontFamily == "Avenir45")
					{
						Control.Font = UIFont.FromName("AvenirLTStd-Book.ttf", 15f);
					}
					else
					{
					}
					if (element.CustomFontSize != 0)
					{
						UIFont font = Control.Font.WithSize(element.CustomFontSize);
						Control.Font = font;
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
					var textGiven = element.EnterText;
					Control.BorderStyle = UITextBorderStyle.None;
					Control.AdjustsFontSizeToFitWidth = true;
					Control.Layer.CornerRadius = 10;
					Control.ExclusiveTouch = true;
					if (!string.IsNullOrWhiteSpace(textGiven))
					{
						//Control.Text = textGiven;
					}
					Control.TextColor = UIColor.Black;
					if (element.CustomFontFamily == "Avenir65")
					{
						Control.Font = UIFont.FromName("AvenirLTStd-Medium.ttf", 15f);
					}
					else if (element.CustomFontFamily == "Avenir45")
					{
						Control.Font = UIFont.FromName("AvenirLTStd-Book.ttf", 15f);
					}
					else
					{
					}
					if (element.CustomFontSize != 0)
					{
						UIFont font = 
        Control.Font.WithSize(element.CustomFontSize);
						Control.Font = font;
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
		   }
	   }
     }
