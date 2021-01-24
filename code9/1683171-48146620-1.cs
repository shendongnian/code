    private  void image_PointerEntered(object sender, PointerRoutedEventArgs e)
    { 
        currentscroll.ChangeView(0, 0, 1.2f ); 
    }
    private  void image_PointerExited(object sender, PointerRoutedEventArgs e)
    { 
        currentscroll.ChangeView(0, 0, 1.0f); 
    }
