      void ShowMore(){
        TopLayout.TranslateTo(0, -TopLayout.Bounds.Height, 300,  Easing.Linear);
        MoreDetails.LayoutTo(new Rectangle(0, 0, MoreDetails.Bounds.Width, MoreDetails.Bounds.Height + TopLayout.Bounds.Height), 300, Easing.Linear);
        }
        
        void ShowLess(){
        TopLayout.TranslateTo(0, 0, 300,  Easing.Linear);
        MoreDetails.LayoutTo(new Rectangle(0, MoreDetails.Bounds.Height, MoreDetails.Bounds.Width, MoreDetails.Bounds.Height - MoreDetails.Bounds.Height), 300, Easing.Linear);
        }
