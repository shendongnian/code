    foreach (var filename in names_of_files)
    {
        using (StreamReader file = new StreamReader(filename))
        {
            if (filename.Contains(".txt"))
            {
                // Process text tile
                MyTextProcessingMethod(file);
            }
            else if (filename.Contains(".png"))
            {
                // Do something with the image
                MyImageProcessingMethod(file);
            }
            else if (filename.Contains("_specialCode")) {
                // Another file that has special processing based on its file name
                MySpecialProcessingMethod(file);
            }
        }
    }
