    using (ZMessage message = subscriber.ReceiveMessage()){
        Console.WriteLine("Message received!");
        string pubID = message[0].ReadString();
        /*receive bytearray from publisher*/
        content = message[1].Read();
        Console.WriteLine("size of content: " + message[1].Length);
        /*create BitmapSource out of the bytearray you receive.*/
        Application.Current.Dispatcher.BeginInvoke(new Action(() =>
        {
          BitmapSource source = BitmapSource.Create(1920, 1080, 72, 72, 
            PixelFormats.Bgra32, BitmapPalettes.Gray256, content, 1920 * 4);
          if (source != null){
             Console.WriteLine("source is created");
          }
          /*display image on screen*/
          videoView.Source = source;
          Console.WriteLine("videoView updated");          
        }));
    }
