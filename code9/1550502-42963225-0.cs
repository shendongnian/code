    public partial class RandomImageTest : Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                // Create a list to hold final image information
                List<ImageData> images = new List<ImageData>();
    
                // Create a temporary list for initial image data
                List<ImageData> imagesTemp = new List<ImageData>();
                Random rnd = new Random();
    
                // Add image data to temporary list
                imagesTemp.Add(new ImageData() { Label = "Label 1", Path = "//image1.gif" });
                imagesTemp.Add(new ImageData() { Label = "Label 2", Path = "//image2.gif" });
                imagesTemp.Add(new ImageData() { Label = "Label 3", Path = "//image3.gif" });
                imagesTemp.Add(new ImageData() { Label = "Label 4", Path = "//image4.gif" });
    
                // Use a for loop to retrieve a random item from the temporary list
                // Copy that item to the final list for later use
                // Remove the used item from the temporary list so that it is not retrieved more than once
                for (int i = imagesTemp.Count; i > 0; i--)
                {
                    int rand = rnd.Next(0, i);
                    images.Add(imagesTemp[rand]);
                    imagesTemp.RemoveAt(rand);
                }
    
                // Use the final (randomised) list to set the properties of the four images and labels
                Label1.Text = images[0].Label;
                Label2.Text = images[1].Label;
                Label3.Text = images[2].Label;
                Label4.Text = images[3].Label;
    
    
                Image1.ImageUrl = images[0].Path;
                Image2.ImageUrl = images[1].Path;
                Image3.ImageUrl = images[2].Path;
                Image4.ImageUrl = images[3].Path;
            }
    
            // A class to store any information regarding an image
            // Can add 'alt' text etc. if required
            private class ImageData
            {
                public string Label { get; set; }
                public string Path { get; set; }
            }
        }
