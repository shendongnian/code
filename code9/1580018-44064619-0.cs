     private async void MyBtn_Click(object sender, RoutedEventArgs e)
     {
         using (HttpClient client = new HttpClient())
         {
             var svg = new SvgImageSource();
             try
             {
                 var response = await client.GetAsync(new Uri("http://www.iconsvg.com/Home/downloadPicture?route=1333158662629220352&name=%E5%9C%86%E5%BD%A2%E7%9A%84_circular164"));
    
                 if (response != null && response.StatusCode == HttpStatusCode.OK)
                 {
                     using (var stream = await response.Content.ReadAsStreamAsync())
                     {
                         using (var memStream = new MemoryStream())
                         {
                             await stream.CopyToAsync(memStream);
                             memStream.Position = 0;
                             await svg.SetSourceAsync(memStream.AsRandomAccessStream());
                             MyImageView.Source = svg;
                         }
                     }
                 }
             }
             catch (Exception ex)
             {
    
             }
         }
     }
   
    <Image x:Name="MyImageView" Source="{Binding imageSource ,Mode=OneWay,Converter={StaticResource MyConvert }}" />
