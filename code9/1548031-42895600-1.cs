     public static void saveImage(Bitmap bmp)
     {
          try
          {
              using (var os = new System.IO.FileStream(Android.OS.Environment.ExternalStorageDirectory + "/DCIM/Camera/MikeBitMap2.jpg", System.IO.FileMode.CreateNew))
               {
                   bmp.Compress(Bitmap.CompressFormat.Jpeg, 95, os);
               }
           }
           catch (Exception e)
           {
    
           }
       }
