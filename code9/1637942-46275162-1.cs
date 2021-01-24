        class MyButtonRenderer: ButtonRenderer
        {
    
            UILabel labelOne;
            UILabel labelTwo;
    
            public override void LayoutSubviews()
            {
                base.LayoutSubviews();
                nfloat height = Control.Frame.Size.Height;
                nfloat width = Control.Frame.Size.Width;
    
                if (labelOne!=null)
                    labelOne.Frame = new CGRect(0, 0, width, height / 2);
    
                if (labelTwo != null)
                    labelTwo.Frame = new CGRect(0, height / 2, width, height / 2);
    
            }
            protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
            {
                base.OnElementChanged(e);
    
                if (Control != null)
                {
                    var button = e.NewElement as MyButton;
  
                    labelOne = new UILabel();
                    labelOne.Text = button.LabelOneText;
                    labelOne.TextAlignment = UITextAlignment.Center;
                
                    labelTwo = new UILabel();
                    labelTwo.Text = button.LabelTwoText;
                    labelTwo.TextAlignment = UITextAlignment.Center;
    
                    this.AddSubview(labelOne);
                    this.AddSubview(labelTwo);
                }
            }
        }
