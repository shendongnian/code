            private ShowProperties NewShowProperties()
        {
            var showProperties = new ShowProperties { Loop = true, ShowNarration = true };
            showProperties.Append(new KioskSlideMode());  //ITEM #1
            showProperties.Append(new SlideAll());
            showProperties.Append(new PresenterSlideMode());
            return showProperties;
        }
