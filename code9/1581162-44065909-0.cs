    public static System.Drawing.Bitmap CombineBitmap(string[] files, int colCount)
    {
        //read all images into memory
        List<System.Drawing.Bitmap> images = new List<System.Drawing.Bitmap>();
        // Where each row starts to display the images
        List<int> YPosPerRow = new List<int>() ;
        // First row is known to be at Y position = 0 
        YPosPerRow.Add(0);
    
        System.Drawing.Bitmap finalImage = null;
        try
        {
            int width = 0;
            int height = 0;
            int rowHeight = 0;
            int rowWidth = 0;
            // Calculate the number of rows required to display the files
            // per the colCount passed as argument..
            int rowCount = (files.Length / colCount) + 1;
            int index = 0;
            
            // Loop for each row
            for (int x = 0; x < rowCount; x++)
            {
                // Loop for each column
                for (int y = 0; y < colCount; y++)
                {
                    // Should stop the loop if the bitmaps count is not
                    // exactly divisible for the colCount requested
                    if (index >= files.Length)
                        break;
    
                    //create a Bitmap from the file and add it to the list
                    System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(files[index]);
    
                    // recalculate the height/width for the current row
                    rowWidth += bitmap.Width;
                    rowHeight = bitmap.Height > rowHeight ? bitmap.Height : rowHeight;
                    images.Add(bitmap);
                    index++;
                }
                // Running height
                height += rowHeight;
                // Where to put in the Y axis the next row when merging
                YPosPerRow.Add(height);
                // Running width
                width = (rowWidth > width ? rowWidth : width);
                // reset for next loop
                rowWidth = 0;
                rowHeight = 0;
            }
    
            //create a bitmap to hold the combined image
            finalImage = new System.Drawing.Bitmap(width, height);
            index = 0;
            //get a graphics object from the image so we can draw on it
            using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(finalImage))
            {
                //set background color
                g.Clear(System.Drawing.Color.White);
                // Again loop over rows/columns
                for (int x = 0; x < rowCount; x++)
                {
                    int offsetX = 0;
                    for (int y = 0; y < colCount; y++)
                    {
                        // Exit if not exactly divisible
                        if (index >= files.Length)
                            break;
    
                        using (Bitmap image = images[index])
                        {
                            g.DrawImage(image,
                            new System.Drawing.Rectangle(offsetX, YPosPerRow[x], image.Width, image.Height));
                            offsetX += image.Width;
                        }
                        index++;
                    }
                }
            }
            return finalImage;
        }
        catch (Exception ex)
        {
            if (finalImage != null)
                finalImage.Dispose();
            throw;
        }
        finally
        {
            //clean up memory
            foreach (System.Drawing.Bitmap image in images)
            {
                image.Dispose();
            }
        }
    }
