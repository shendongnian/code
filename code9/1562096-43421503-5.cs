    Draw.PointerEvent += (sender, e) =>
                    {
                        switch (e.Type)
                        {
                            case TouchImage.PointerEventArgs.PointerEventType.Down:
                            case TouchImage.PointerEventArgs.PointerEventType.Move: // delete move case if not needed
                                if (e.PointerDown)
                               { // Touch down
       }
                                break;
                            case TouchImage.PointerEventArgs.PointerEventType.Up:
                            case TouchImage.PointerEventArgs.PointerEventType.Cancel:
                           //Touch released
                                break;
                            default:
                                break;
                        }
    };
