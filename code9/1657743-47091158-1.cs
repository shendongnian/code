    private void AddGreenBox()
    {
        // create view and set background
        greenView = new UIView();
        greenView.BackgroundColor = UIColor.Green;
        this.View.AddSubview(greenView);
        greenView.TranslatesAutoresizingMaskIntoConstraints = false;
        View.AddConstraints(new[] {
            NSLayoutConstraint.Create(this.greenView, NSLayoutAttribute.Leading, NSLayoutRelation.Equal, this.View, NSLayoutAttribute.Leading, 1, 15),
            NSLayoutConstraint.Create(this.greenView, NSLayoutAttribute.Trailing, NSLayoutRelation.Equal, this.View, NSLayoutAttribute.Trailing, 1, -15) ,
            NSLayoutConstraint.Create(this.greenView, NSLayoutAttribute.Top, NSLayoutRelation.Equal, this.View, NSLayoutAttribute.Top, 1, 15),
            NSLayoutConstraint.Create(this.greenView, NSLayoutAttribute.Bottom, NSLayoutRelation.Equal, this.View, NSLayoutAttribute.Bottom, 1, -15)
        });
    }
