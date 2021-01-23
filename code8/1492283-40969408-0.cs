        private void common()
        {
            if (Headername[CI] == "Yellow")
            {
                if (objnamewritten[CI].Equals("Banana") || objnamewritten[CI].Equals("lemomn") || objnamewritten[CI].Equals("Sun"))
                {
                    ppup.Height = Window.Current.Bounds.Height;
                    ppup.IsOpen = true;
                }
                else
                {
                    ppup1.Height = Window.Current.Bounds.Height;
                    ppup1.IsOpen = true;
                }
            }
        }
