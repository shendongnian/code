      void ShowMore{
        TopLayout.TranslateTo(-TopLayout.Bounds.Height);
        MoreDetails.LayoutTo(new Rectangle(0, 0, MoreDetails.Bounds.Width, MoreDetails.Bounds.Height + TopLayout.Bounds.Height), 300, Easing.None);
        }
        
        void ShowLess{
        TopLayout.TranslateTo(0);
        MoreDetails.LayoutTo(new Rectangle(0, MoreDetails.Bounds.Height, MoreDetails.Bounds.Width, MoreDetails.Bounds.Height - MoreDetails.Bounds.Height), 300, Easing.None);
        }
