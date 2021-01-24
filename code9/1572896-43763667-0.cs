    string m1, m2, m3, m4;  // put some nice file paths in here
    using (var m4Stream = File.OpenWrite(m4)) {
        m4Stream.SetLength(0);
        using (var m1Stream = File.OpenRead(m1)) {
            m1Stream.CopyTo(m4Stream, 512);
        }
        using (var m2Stream = File.OpenRead(m2)) {
            m2Stream.CopyTo(m4Stream, 512);
        }
        using (var m3Stream = File.OpenRead(m3)) {
            m3Stream.CopyTo(m4Stream, 512);
        }
    }
