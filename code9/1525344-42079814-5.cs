    MemoryStream ms = new MemoryStream();
    Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
    Graphics graphics = Graphics.FromImage(bitmap);
    graphics.CopyFromScreen(0, 0, 0, 0, bitmap.Size);
    bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
    Console.WriteLine(ms.Length.ToString());
    writeToStream(combineBytes(Encoding.ASCII.GetBytes(ms.Length.ToString()), ms.ToArray()));
    ms.Close();
