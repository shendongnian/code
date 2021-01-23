    public static void ZipVerification()
    {
        using (var zip = new ZipArchive(stream, ZipArchiveMode.Read))
        {
            // Print stream position before.
            Console.WriteLine(stream.Position);
            foreach (var entry in zip.Entries)
            {
                using (var entryStream = entry.Open())
                {
                    entryStream.CopyTo(System.IO.Stream.Null);
                }
            }
            // Print stream position after.
            Console.WriteLine(stream.Position);
        }
    }
