    public string CreatePDF(int variant, string subFolder, string reportName, byte[] result)
    {
        //We want 16 variants, but we pass in a number from 1 to 48, so use modulo division to convert this back to a 1 to 16 range
        variant = (variant - 1) % 16 + 1;
        Console.WriteLine("Saving " + reportName + "_Variant_" + variant.ToString("00") + ".pdf");
        try
        {
            //Determine the target folder/ filename for the PDF
            //Snail Mail has its own folder, all PDFs go into that folder and then are manually processed
            string folder = @"S:\Change Management Documents\SMETS1\Inheritance Comms\" + subFolder + @"\";
            string filename = reportName + "_Variant_" + variant.ToString("00") + ".pdf";
            //Remove any existing content
            string[] filePaths = Directory.GetFiles(folder, filename);
            foreach (string filePath in filePaths)
                File.Delete(filePath);
            //Now save the PDF
            string path = folder + @"\" + filename;
            FileStream stream = File.Create(path, result.Length);
            stream.Write(result, 0, result.Length);
            stream.Close();
            return filename;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return "";
        }
    }
