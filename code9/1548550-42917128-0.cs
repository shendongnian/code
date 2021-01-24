    public void OnPictureTaken(byte[] data, Android.Hardware.Camera camera)
            {
                _camera.StopPreview();
                Bitmap picture = BitmapFactory.DecodeByteArray(data, 0, data.Length);
                Intent PictureActivity = new Intent(this, typeof(PictureActivity));
                PictureActivity.PutExtra("Photo", picture);
                this.StartActivity(PictureActivity);
                _camera.StartPreview();
            }
