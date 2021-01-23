    if (((Grid)sender).Children.Count > 0)
            {
                gridBackground = (ImageBrush)(((Grid)sender).Background);
                System.Windows.Controls.Image gridBackImage = new System.Windows.Controls.Image();
                gridBackImage.Source = gridBackground.ImageSource;
    
                ImageCar.Source = gridBackImage.Source;
            }
