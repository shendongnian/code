	///<summary>
	///Reads mono 8 or 16 bit WAV files into an Int16 array
	///</summary>
	public class RiffLoader
	{
		public enum RiffStatus { Unknown = 0, OK, FileError, FormatError, UnsupportedFormat };
		int channels;
		int blockAlign;
		int bitsPerSample;
		int numberOfSamples;
		Int16[] waveData;
		RiffStatus status = RiffStatus.Unknown;
		List<String> errorMessages = new List<string>();
		String source;
		public String SourceName { get { return source; } }
		public RiffStatus Status { get { return status; } }
		public String[] Messages { get { return errorMessages.ToArray(); } }
		public Int16[] WaveData { get { return waveData; } }
		public RiffLoader(String fileName)
		{
			source = fileName;
			try
			{
				using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
				{
					byte[] buffer;
					BinaryReader reader = new BinaryReader(fs);
					buffer = reader.ReadBytes(44);
					if (buffer.Length < 44 || !validateHeader(buffer))
					{
						status = RiffStatus.FormatError;
						errorMessages.Add("Error in header format");
					}
					else
					{
						int bytesRequired = blockAlign * numberOfSamples;
						if (fs.Length - fs.Position >= bytesRequired)
						{
							waveData = new Int16[numberOfSamples];
							buffer = reader.ReadBytes(bytesRequired);
							int i = 0, j = 0;
							while (i < buffer.Length && j < bytesRequired)
							{
								if (blockAlign == 1)
									waveData[j++] = buffer[i++];
								else
								{
									waveData[j++] = (Int16)(buffer[i] | buffer[i + 1] << 8);
									i += 2;
								}
							}
							status = RiffStatus.OK;
							errorMessages.Add(String.Format("{0} Loaded succesfully. {1} samples available", fileName, numberOfSamples));
						}
						else
							status = RiffStatus.FileError;
					}
				}
			}
			catch (Exception e)
			{
				status = RiffStatus.FileError;
				errorMessages.Add(String.Format("Error loading \"{0}\": {1}", e.Message));
			}
		}
		private static byte[] riffPrefix = new byte[] { 0x52, 0x49, 0x46, 0x46 };	// "RIFF"
		private static byte[] formatPrefix = new byte[] { 0x66, 0x6d, 0x74, 0x20 }; // "fmt "
		private static byte[] dataPrefix = new byte[] { 0x64, 0x61, 0x74, 0x61 };	// "data "
		private static byte[] wavePrefix = new byte[] { 0x57, 0x41, 0x56, 0x45 };	// "WAVE"
		bool validateHeader(byte[] data)
		{
			bool goodRiffPrefix = true;
			bool goodFormatPrefix = true;
			bool goodDataPrefix = true;
			bool goodWavePrefix = true;
			for (int i = 0; i < 4; i++)
			{
				if (data[i] != riffPrefix[i])
					goodRiffPrefix = false;
				if (data[8 + i] != wavePrefix[i])
					goodWavePrefix = false;
				if (data[12 + i] != formatPrefix[i])
					goodFormatPrefix = false;
				if (data[36 + i] != dataPrefix[i])
					goodDataPrefix = false;
			}
			int byteCount = data[40] | data[41] << 8 | data[42] << 16 | data[43] << 24;
			if (goodRiffPrefix && goodWavePrefix && goodFormatPrefix && goodDataPrefix)
			{
				channels = data[22] | data[23] << 8;
				blockAlign = data[32] | data[33] << 8;
				bitsPerSample = data[34] | data[35] << 8;
				if (channels != 1)
				{
					status = RiffStatus.UnsupportedFormat;
					errorMessages.Add(String.Format("{0} channels not supported", channels));
				}
				if (bitsPerSample != 8 && bitsPerSample != 16)
				{
					status = RiffStatus.UnsupportedFormat;
					errorMessages.Add(String.Format("{0} bits per sample not supported", bitsPerSample));
				}
				if (bitsPerSample == 8 && blockAlign != 1 || bitsPerSample == 16 && blockAlign != 2)
				{
					status = RiffStatus.UnsupportedFormat;
					errorMessages.Add(String.Format("Block alignment {0} not supported", blockAlign));
				}
				if (status != RiffStatus.Unknown)
					return false;
			}
			numberOfSamples = byteCount / blockAlign;
			return true;
		}
	}
