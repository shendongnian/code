    var touchGesture = new UITapGestureRecognizer((tg) =>
    {
        if(!imageView.Highlighted){
            imageView.Highlighted = true;
            imageView.AnimationImages = new UIImage[]{imageView.Image};
            imageView.Image = DrawSelectedBorder(imageView.Image);
        }else{
            imageView.Highlighted = false;
            imageView.Image = imageView.AnimationImages[0];
            System.Diagnostics.Debug.WriteLine(imageView.AccessibilityLabel);
        }
    });
