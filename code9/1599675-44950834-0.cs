    var theImage = new Image<Gray, byte>(@"d:\temp\lena.jpg");
            for (int i = theImage.Rows - 1; i >= 0; i--)
            {
                for (int j = theImage.Cols - 1; j >= 0; j--)
                {
                    if(theImage.Data[i,j,0]>byte.MaxValue/2)
                    {
                            theImage.Data[i, j, 0] = byte.MaxValue;
                    }
                    else
                    {
                        theImage.Data[i, j, 0] = 0;
                    }
                        
                }
            }
