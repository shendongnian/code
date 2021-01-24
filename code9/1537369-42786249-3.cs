               using (FileStream fs = File.Open(filename, FileMode.Open))
                {
                    BinaryReader reader = new BinaryReader(fs);
                    int chunkID = reader.ReadInt32();
                    int fileSize = reader.ReadInt32();
                    int riffType = reader.ReadInt32();
                    int fmtID;
                    long _position = reader.BaseStream.Position;
                    while (_position != reader.BaseStream.Length-1)
                    {
                        reader.BaseStream.Position = _position;
                        int _fmtId = reader.ReadInt32();
                        if (_fmtId == 544501094) {
                            fmtID = _fmtId;
                            break;
                        }
                        _position++;
                    }
                    int fmtSize = reader.ReadInt32();
                    int fmtCode = reader.ReadInt16();
                    int channels = reader.ReadInt16();
                    int sampleRate = reader.ReadInt32();
                    int byteRate = reader.ReadInt32();
                    int fmtBlockAlign = reader.ReadInt16();
                    int bitDepth = reader.ReadInt16();
                    int fmtExtraSize;
                    if (fmtSize == 18)
                    {
                        fmtExtraSize = reader.ReadInt16();
                        reader.ReadBytes(fmtExtraSize);
                    }
                    int dataID = reader.ReadInt32();
                    int dataSize = reader.ReadInt32();
                    byte[] byteArray = reader.ReadBytes(dataSize);
                    int bytesForSamp = bitDepth / 8;
                    int samps = dataSize / bytesForSamp;
                    float[] asFloat = null;
                    switch (bitDepth)
                    {
                        case 16:
                            Int16[] asInt16 = new Int16[samps];
                            Buffer.BlockCopy(byteArray, 0, asInt16, 0, dataSize);
                            IEnumerable<float> tempInt16 =
                                from i in asInt16
                                select i / (float)Int16.MaxValue;
                            asFloat = tempInt16.ToArray();
                            break;
                        default:
                            return false;
                    }
                    //For one channel wav audio
                    floatLeftBuffer.AddRange(asFloat);
