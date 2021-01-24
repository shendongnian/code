    void Method1() {
        foreach (string name in OpenFileDialog1.FileNames) {
            using (var bitmap1 = new Bitmap(name))
            {
                ... // process bitmap
            }
        }
    }
