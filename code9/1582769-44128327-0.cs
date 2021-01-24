    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    namespace sortinglists
    {
        public class MainProgram
	    {
    		public static void Main()
    		{
    			var imageUrlsNumbers = new List<string>();
    			imageUrlsNumbers.Add("c:/a/b/1.jpg");
    			imageUrlsNumbers.Add("c:/a/b/10.jpg");
    			imageUrlsNumbers.Add("c:/a/b/2.jpg");
                CustomSort(ref imageUrlsNumbers);
    			foreach (var imageUrl in imageUrlsNumbers)
    			{
    				Console.WriteLine(imageUrl);
    			}
                var imageUrlsText = new List<string>();
                imageUrlsText.Add("c:/a/b/DSC_1.jpg");
                imageUrlsText.Add("c:/a/b/DSC_10.jpg");
                imageUrlsText.Add("c:/a/b/DSC_2.jpg");
    
                CustomSort(ref imageUrlsText);
    
                foreach (var imageUrl in imageUrlsText)
                {
                    Console.WriteLine(imageUrl);
                }
    
    		}
    		public static void CustomSort(ref List<string> imageUrls)
    		{
    			if (imageUrls
    				.Select(s => s.Substring(s.LastIndexOf("/", StringComparison.OrdinalIgnoreCase) + 1))
    				.Select(t => t.Substring(0, t.IndexOf(".", StringComparison.OrdinalIgnoreCase)))
    				.Where(u => new Regex("[A-Za-z_]").Match(u).Success)
    				.Any())
    			{
    				imageUrls = imageUrls
    					.Select(x => x.Substring(x.LastIndexOf("/", StringComparison.OrdinalIgnoreCase) + 1))
    					.ToList();
    			}
                else
                {
    				imageUrls = imageUrls
    	                .Select(v => v.Substring(v.LastIndexOf("/", StringComparison.OrdinalIgnoreCase) + 1))
    	                .OrderBy(w => Convert.ToInt32(w.Substring(0, w.LastIndexOf(".", StringComparison.OrdinalIgnoreCase))))
    	                .ToList();
                }
    		}
    	}
    }
