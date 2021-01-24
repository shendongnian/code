        CellImageView = new UIButton();
        CellImageView.TouchUpInside += delegate
        {
            UIAlertView alert = new UIAlertView()
            {
                Title = HeadingLabel.Text,
                Message = SubheadingLabel.Text
            };
            alert.AddButton("OK");
            alert.Show();
        };
