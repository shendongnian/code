    public int CompareImgSimilarityvalue(String filename1, String filename2)
        {
            List<bool> iHash1 = GetHash(new Bitmap(filename1));
            List<bool> iHash2 = GetHash(new Bitmap(filename2));
            //determine the number of equal pixel (x of 256) 256 is a perfect match
            return iHash1.Zip(iHash2, (i, j) => i == j).Count(eq => eq);
        }
        public static void Analyis()
        {
            string[] files = Directory.GetFiles(@"C:\Users\ChawlaRa\Desktop\FilezilleIMGS\MTO_Image\", "*.jpg");
            Array.Sort(files);
            int equalElements = 0;
            for (var i = 0; i < (files.Length - 1); i++)
            {
                equalElements = CompareImgSimilarityvalue(files[i], files[i + 1]);
                //if LESS THAN 98% similar
                if (equalElements < 253.44)
                {
                    //images different
                    Console.WriteLine("NOT Same Images");
                    Console.WriteLine("These images below are DIFFERENT - conclusion CAMERA WORKING");
                    Console.WriteLine(files[i] + ".jpg");
                    Console.WriteLine(files[i+1] + ".jpg");
                    using (writetext)
                    {
                        writetext.Write(files[i] + ".jpg");
                        writetext.Write(",");
                        writetext.Write(files[i+1] + ".jpg");
                        writetext.Write(",");
                    }
                    Console.WriteLine("The image file names of the non working cameras above have been appened to list of nonworking cameras.");
                }
                else
                //images same
                {
                    Console.WriteLine("These images below are the same- conclusion CAMERA NOT WORKING ");
                    Console.WriteLine(files[i] + ".jpg");
                    Console.WriteLine(files[i+1] + ".jpg");
                    using (writetext2)
                    {
                        writetext2.Write(files[i] + ".jpg");
                        writetext2.Write(",");
                        writetext2.Write(files[i+1] + ".jpg");
                        writetext2.Write(",");
                    }
                    Console.WriteLine("The image file names of the non working cameras above have been appened to list of nonworking cameras.");
                }
            }
            // Console.WriteLine(equalElements);
            Console.ReadLine();
        }
