    CGRect rect = new CGRect(0, UIApplication.SharedApplication.StatusBarFrame.Height, UIScreen.MainScreen.ApplicationFrame.Width , UIScreen.MainScreen.ApplicationFrame.Height);
    UIScrollView Mainscrollview = new UIScrollView(rect) { BackgroundColor = UIColor.Gray };
    View.AddSubview(Mainscrollview);
    this.View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
    var someLablel = new UILabel();
    var button = new UIButton { BackgroundColor = UIColor.Gray };
    var blueView = new UIView { BackgroundColor = UIColor.Blue };
    Mainscrollview.AddSubviews( someLablel,button, blueView);
            
    Mainscrollview.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
    Mainscrollview.AddConstraints(
         someLablel.AtTopOf(Mainscrollview, 50),
         someLablel.AtLeftOf(Mainscrollview, 10),
         someLablel.AtRightOf(Mainscrollview, 10),
         someLablel.Height().EqualTo(50),
         button.AtBottomOf(someLablel, 10),
         button.WithSameLeft(someLablel),
         button.WithSameRight(someLablel),
         button.WithSameHeight(button),
         blueView.AtBottomOf(button, 10),
         blueView.WithSameLeft(someLablel),
         blueView.WithSameRight(someLablel),
         blueView.AtBottomOf(Mainscrollview, 10)
    );
    //*do as above*
    //blueView.AddSubviews(SubViewLabel1, Another , more);
    //blueView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
    //blueView.AddConstraints( );
