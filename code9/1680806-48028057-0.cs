    private void SetImage(PictureBox target)
    {
         List<Image> images = new List<Image>();
         images.Add(Properties.Resources.Abessinier);
         images.Add(Properties.Resources.Bengal);
         images.Add(Properties.Resources.American_curl);
         images.Add(Properties.Resources.Balines);
         images.Add(Properties.Resources.brittisk_korthår);
         Random random = new Random();
         var selectedIndex = random.Random(0, images.count -1);
         target.Image = images[selectedIndex];
         
         switch(selectedIndex)
         {
             case 0:
                   button1.Text = "some text";
                   button2.Text = "some text";
                   button3.Text = "some text";
                   button4.Text = "some text"; 
                   break; 
             case 1:
                   button1.Text = "some text";
                   button2.Text = "some text";
                   button3.Text = "some text";
                   button4.Text = "some text"; 
                   break;
                   // Keep going with additional statements, and include a default too... 
         }
    }
