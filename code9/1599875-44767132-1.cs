    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace ConsoleApp1
    {
    class Program
    {
        static int equalElements;
        //parse image file names into txt file for working cameras
        static StreamWriter writetext = new StreamWriter(@"c:\Users\ChawlaRa\Desktop\FilezilleIMGS\MTO_Image\working.txt", true);
        static StreamWriter writetext2 = new StreamWriter(@"c:\Users\ChawlaRa\Desktop\FilezilleIMGS\MTO_Image\notworking.txt", true);
        static void Main(string[] args)
        {
            Analyis();
        }
        //method which converts image to 16*16 gets hash code
        public static List<bool> GetHash(Bitmap bmpSource)
        {
            List<bool> lResult = new List<bool>();
            //create new image with 16x16 pixel
            Bitmap bmpMin = new Bitmap(bmpSource, new Size(16, 16));
            for (int j = 0; j < bmpMin.Height; j++)
            {
                for (int i = 0; i < bmpMin.Width; i++)
                {
                    //reduce colors to true / false                
                    lResult.Add(bmpMin.GetPixel(i, j).GetBrightness() < 0.5f);
                }
            }
            return lResult;
        }
        public static int CompareImgSimilarityvalue(String filename1, String filename2)
        {
            List<bool> iHash1 = GetHash(new Bitmap(filename1));
            List<bool> iHash2 = GetHash(new Bitmap(filename2));
            //determine the number of equal pixel (x of 256) 256 is a perfect match
            equalElements = iHash1.Zip(iHash2, (i, j) => i == j).Count(eq => eq);
            return equalElements;
        }
        public static void Analyis()
        {
            string[] files = Directory.GetFiles(@"C:\Users\ChawlaRa\Desktop\FilezilleIMGS\MTO_Image");
            for (var i = 0; i < (files.Length - 1); i++)
            {
                string filename1 = files[i];
                string filename2 = files[i + 1];
                CompareImgSimilarityvalue(filename1, filename2);
                //if LESS THAN 98% similar
                if (equalElements < 253.44)
                {
                    //images different
                    Console.WriteLine("NOT Same Images");
                    Console.WriteLine("These images below are DIFFERENT - conclusion CAMERA WORKING");
                    Console.WriteLine(filename1);
                    Console.WriteLine(filename2);
                    using (writetext)
                    {
                        writetext.Write(filename1);
                        writetext.Write(",");
                        writetext.Write(filename2);
                        writetext.Write(",");
                    }
                    Console.WriteLine("The image file names of the non working cameras above have been appened to list of nonworking cameras.");
                }
                else
                //images same
                {
                    Console.WriteLine("These images below are the same- conclusion CAMERA NOT WORKING ");
                    Console.WriteLine(filename1);
                    Console.WriteLine(filename2);
                    using (writetext2)
                    {
                        writetext2.Write(filename1);
                        writetext2.Write(",");
                        writetext2.Write(filename2);
                        writetext2.Write(",");
                    }
                    Console.WriteLine("The image file names of the non working cameras above have been appened to list of nonworking cameras.");
                }
                // Console.WriteLine(equalElements);
                Console.ReadLine();
            }
        }
    }
    }
