    using (MemoryStream memoryStream = new MemoryStream())
            {
                //saved my chart to an memoryStream
                Chart2.SaveImage(memoryStream, ChartImageFormat.Png);
                //saved memorystream to byte array
                byte[] byteArrayIn = memoryStream.ToArray();
                
                //saving byte back to an Image
                Image image1 = new Image();
                image1.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteArrayIn, 0, byteArrayIn.Length);
    
                newChart.Controls.Add(image1);
                divRadarChart.Visible = false;
            }
