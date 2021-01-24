            // A dictionary to hold the images by their names
            var images = new Dictionary<string, Image>();
            // Read the resources of the currently executing assembly
            var assembly = Assembly.GetExecutingAssembly();
            // All the names of the files that have a "Build action = Embedded Resource"
            var names = assembly.GetManifestResourceNames();
            foreach (var name in names)
            {
                // Check if it's the resource we want
                if (name.EndsWith(".png", StringComparison.InvariantCultureIgnoreCase))
                {
                    // Create a 'sanitized name' which excludes the "{AssemblyName}.Resources." and ".png" part
                    var prefix = $"{assembly.GetName().Name}.Resources.".Length;
                    var sanitizedName = name.Substring(prefix, name.IndexOf(".png") - prefix);
                    // Load the image from the Manifest Resource Stream
                    var image = Image.FromStream(assembly.GetManifestResourceStream(name));
                    // Add the image to the dictionary
                    images.Add(sanitizedName, image);
                }
            }
            // ...
            // Retrieve the image from the dictionary by it's name
            button1.BackgroundImage = images["_5_of_spades"];
            // ...
            // If at any point forward you wish to unload the images from memory (Besides quiting the application)
            button1.BackgroundImage = null; // Make sure no controls use the image anymore
            Parallel.ForEach(images.Values, (image) => { image.Dispose(); });   // Cleanup in-memory images (Linq and TPL to make it a one-liner)
