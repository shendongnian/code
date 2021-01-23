    Thanks for Alex Sorokoletov, Now ,I have a solution for my project , It is like this:
       
            nint pixLen = imageWidth * imageHeigh;
            nint count = pixLen  * 4 ;
            byte[] newImageArr = new byte[count];
     using (var context = new CGBitmapContext(newImageArr, imageWidth, imageHeigh,
                bitsPerComponent, bytesPerRow, colorSpace, CGImageAlphaInfo.PremultipliedLast))
            {
                RectangleF imageRec = new RectangleF(0, 0, imageWidth, imageHeigh);
                context.DrawImage(imageRec, myCgImage);
                for (int i = 0; i < count; i = i+4)
                {
                    float clorRed = (newImageArr[i]) ;
                    float clorGreen = (newImageArr[i + 1]) ;
                    float clorBlue = (newImageArr[i + 2]) ;
                }
           }
