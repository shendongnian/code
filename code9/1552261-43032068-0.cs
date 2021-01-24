        public void changePhoto()
        {
            int MyPhoto;
            if (edit.Text != string.Empty)
            {
                try
                {
                    MyPhoto = (int)typeof(Resource.Drawable).GetField(edit.Text).GetValue(null);
                }
                catch
                {
                    MyPhoto = Resource.Drawable.ErrorPhoto;
                }
                img.SetImageResource(MyPhoto);
            }
        }
        button.Click += delegate 
        {
            changePhoto();
        }; 
