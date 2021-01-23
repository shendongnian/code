            Image img_ding = new Image();
            var uri = String.Format("pack://application:,,,/Images/All_Sprites/{0:000}.png", i);
            //  N.B. UriKind.Absolute is redundant, sigh
            BitmapImage carBitmap = new BitmapImage(new Uri(uri, UriKind.Absolute ));
            img_ding.Source = carBitmap;
