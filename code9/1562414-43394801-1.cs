        const string yourfile = "buffer1";
        const string tempfile = "buffer1edit.bin";
        System.IO.FileInfo fi = new System.IO.FileInfo(yourfile);
        if (yourfile.Length > 50)
        {
            using (System.IO.FileStream originalfile = System.IO.File.Open(yourfile, System.IO.FileMode.Open),
                newfile = System.IO.File.Open(tempfile, System.IO.FileMode.CreateNew))
            {
                originalfile.Seek(50, System.IO.SeekOrigin.Begin);
                originalfile.CopyTo(newfile);
            }
            System.IO.File.Delete(yourfile);
            System.IO.File.Move(tempfile, yourfile);
        }
