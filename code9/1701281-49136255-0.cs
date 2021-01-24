            protected override  void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            // this works fine:
            using (System.IO.Stream stream = this.ContentResolver.OpenOutputStream(data.Data, "w"))
            {
                using (var javaStream = new Java.IO.BufferedOutputStream(stream))
                {
                    var b = new byte[1000000];
                    javaStream.Write(b, 0, b.Length);
                    javaStream.Flush();
                    javaStream.Close();
                }
            }
            // the direct writing on the System.IO.Stream failed:
            //using (System.IO.Stream stream = this.ContentResolver.OpenOutputStream(data.Data, "w"))
            //{
            //    var b = new byte[1000000];
            //    stream.Write(b, 0, b.Length);
            //    stream.Flush();
            //    stream.Close();
            //}
            base.OnActivityResult(requestCode, resultCode, data);
        }
