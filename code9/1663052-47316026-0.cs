    const int targetPosition = 4;
    BinaryReader reader = new BinaryReader(stream);
    using (reader) {
        if (stream.CanSeek) {
            stream.Position = targetPosition;
        }
        else {
            reader.ReadBytes(targetPosition);
        }
        int result = reader.ReadInt32();
    }
