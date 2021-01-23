            Image<Bgr, byte> Image1 = new Image<Bgr, byte>(Properties.Resources.Image1); //Your first image
            Image<Bgr, byte> Image2 = new Image<Bgr, byte>(Properties.Resources.Image2); //Your second image
            double Threshold = 0.8; //set it to a decimal value between 0 and 1.00, 1.00 meaning that the images must be identical
            
            Image<Gray, float> Matches = Image1.MatchTemplate(Image2, TemplateMatchingType.CcoeffNormed);
            for (int y = 0; y < Matches.Data.GetLength(0); y++)
            {
                for (int x = 0; x < Matches.Data.GetLength(1); x++)
                {
                     if (Matches.Data[y, x, 0] >= Threshold) //Check if its a valid match
                     {
                         //Image2 found within Image1
                     }
                }
            }
