    using System;
    using Xamarin.Forms;
    namespace App.Views.Home
    {
    	public class DonationButton : RelativeLayout
    	{
    		#region Properties
    
    		/// <summary>
    		/// Gets or sets the button text.
    		/// </summary>
    		/// <value>The text.</value>
    		public string Text
    		{
    			get { return this._textLabel.Text; }
    			set { this._textLabel.Text = value; }
    		}
    
    		public event EventHandler Clicked;
    
    		#endregion
    
    		#region iVars
    
    		private Image _backgroundImage;
    		private Label _textLabel;
    
    		#endregion
    
    		public DonationButton()
    		{
    			//--------------------------------------------
    			//	Setup the background image
    			//--------------------------------------------
    			this._backgroundImage = new Image()
    			{
    				Source = ImageSource.FromFile("home__donation_button.png")
    			};
    
    			this.Children.Add(this._backgroundImage, (Constraint)null, (Constraint)null, (Constraint)null, (Constraint)null);
    
    			//--------------------------------------------
    			//	Add the label
    			//--------------------------------------------
    
    			/* See: http://stackoverflow.com/a/40942692/1497516 */
    			Func<RelativeLayout, double> getLabelWidth
    				= (p) => this._textLabel.Measure(p.Width, p.Height).Request.Width;
    			Func<RelativeLayout, double> getLabelHeight
    				= (p) => this._textLabel.Measure(p.Width, p.Height).Request.Height;
    
    			this._textLabel = new Label()
    			{
    				TextColor = Color.White,
    				FontAttributes = FontAttributes.Bold,
    				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
    			};
    
    			this.Children.Add(this._textLabel,
    							  Constraint.RelativeToParent((parent) => parent.Width - (getLabelWidth(parent) + 10)),
    							  Constraint.RelativeToView(this._backgroundImage, (parent, view) => (view.Height - getLabelHeight(parent)) / 2)
    							  );
    
    			//--------------------------------------------
    			//	Allow clicks
    			//--------------------------------------------
    			this.GestureRecognizers.Add(new TapGestureRecognizer
    			{
    				Command = new Command(sender =>
    				{
    					if (this.Clicked != null)
    					{
    						this.Clicked(sender, EventArgs.Empty);
    					}
    				}),
    				NumberOfTapsRequired = 1
    			});
    		}
    	}
    }
