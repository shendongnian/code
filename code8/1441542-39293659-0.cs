    using System.IO.Compression;
    
        class Program
        {
            static void Main()
            {
        	// Create a ZIP file from the directory "source".
        	// ... The "source" folder is in the same directory as this program.
        	// ... Use optimal compression.
        	ZipFile.CreateFromDirectory("source", "destination.zip",
        	    CompressionLevel.Optimal, false);
        
        	// Extract the directory we just created.
        	// ... Store the results in a new folder called "destination".
        	// ... The new folder must not exist.
        	ZipFile.ExtractToDirectory("destination.zip", "destination");
            }
        }
