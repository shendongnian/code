    private void carouselOnItemSelected(object sender, SelectedItemChangedEventArgs selectedItemChangedEventArgs)
            {
                CarouselContent carouselContent = selectedItemChangedEventArgs.SelectedItem;
                ViewFlipper viewFlipper = carouselContent.Children[0];
                viewFlipper.FlipState = ViewFlipper.FrontView;
            }
