    var image = Image.FromFile(filePath);
    var client = ImageAnnotatorClient.Create();
    var response = client.DetectDocumentText(image);
    foreach (var page in response.Pages)
    {
        foreach (var block in page.Blocks)
        {
            foreach (var paragraph in block.Paragraphs)
            {
                Console.WriteLine(string.Join("\n", paragraph.Words));
            }
        }
    }
