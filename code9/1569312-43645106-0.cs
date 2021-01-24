    public void Save(string originalFile, int maxWidth, int maxHeight, int quality, string filePath)
            {
                Bitmap image = new Bitmap(originalFile);
                Save(ref image, maxWidth, maxHeight, quality, filePath);
            }
