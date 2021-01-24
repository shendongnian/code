    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    using System.Net.Http;
    using System.Drawing;
    using System.Net;
    using System.Collections.Specialized;
    namespace ConsoleApplication3
    {
    class Program
    {
        static void Main(string[] args)
        {
            Image img = Image.FromFile("image.jpg");
            String base64 = ImageToBase64(img, System.Drawing.Imaging.ImageFormat.Jpeg);
            using (var client = new WebClient())
            {
                var values = new NameValueCollection();
                values["image"] = base64;
                var response = client.UploadValues("https://whatanime.ga/api/search?token=<token>", values);
                var responseString = Encoding.Default.GetString(response);
                Console.WriteLine("data: " + responseString);
                Console.ReadLine();
            }
        }
        public static string ImageToBase64(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }
    }
