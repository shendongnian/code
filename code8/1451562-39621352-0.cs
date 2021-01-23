      void ShowMore{
        TopLayout.LayoutTo(new Rectangle(0, 0, TopLayout.Bounds.Width, TopLayout.Bounds.Height - 100), 300, Easing.None);
        MoreDetails.Layoutto(new Rectangle(0, MoreDetails.Bounds.Y - 100, MoreDetails.Bounds.Width, MoreDetails.Bounds.Height + 100), 300, Easing.None);
        }
        
        void ShowLess{
        TopLayout.LayoutTo(new Rectangle(0, 0, TopLayout.Bounds.Width, TopLayout.Bounds.Height + 100), 300, Easing.None);
        MoreDetails.LayoutTo(new Rectangle(0, MoreDetails.Bounds.Y + 100, MoreDetails.Bounds.Width, MoreDetails.Bounds.Height - 100), 300, Easing.None);
        }
