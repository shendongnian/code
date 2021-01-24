	///<summary>
	///Reads up to 16 bit WAV files
	///</summary>
	///<remarks> Things have really changed in the last 15 years</remarks>
	public class RiffLoader
	{
		public enum RiffStatus { Unknown = 0, OK, FileError, FormatError, UnsupportedFormat };
		LinkedList<Chunk> chunks = new LinkedList<Chunk>();
		RiffStatus status = RiffStatus.Unknown;
		List<String> errorMessages = new List<string>();
		String source;
		public String SourceName { get { return source; } }
		public RiffStatus Status { get { return status; } }
		public String[] Messages { get { return errorMessages.ToArray(); } }
		enum chunkType { Unknown = 0, NoMore, Riff, Fmt, Fact, Data, Error = -1 };
		static Int32 scan32bits(byte[] source, int offset = 0)
		{
			return source[offset] | source[offset + 1] << 8 | source[offset + 2] << 16 | source[offset + 3] << 24;
		}
		static Int32 scan16bits(byte[] source, int offset = 0)
		{
			return source[offset] | source[offset + 1] << 8;
		}
		static Int32 scan8bits(byte[] source, int offset = 0)
		{
			return source[offset];
		}
		abstract class Chunk
		{
			public chunkType Ident = chunkType.Unknown;
			public int ByteCount = 0;
		}
		class RiffChunk : Chunk
		{
			public RiffChunk(int count)
			{
				this.Ident = chunkType.Riff;
				this.ByteCount = count;
			}
		}
		class FmtChunk : Chunk
		{
			int formatCode = 0;
			int channels = 0;
			int samplesPerSec = 0;
			int avgBytesPerSec = 0;
			int blockAlign = 0;
			int bitsPerSample = 0;
			int significantBits = 0;
			public int Format { get { return formatCode; } }
			public int Channels { get { return channels; } }
			public int BlockAlign { get { return blockAlign; } }
			public int BytesPerSample { get { return bitsPerSample / 8 + ((bitsPerSample % 8) > 0 ? 1 : 0); } }
			public int BitsPerSample
			{
				get
				{
					if (significantBits > 0)
						return significantBits;
					return bitsPerSample;
				}
			}
			public FmtChunk(byte[] buffer) : base()
			{
				int size = buffer.Length;
				// if the length is 18 then buffer 16,17 should be 00 00 (I don't bother checking)
				if (size != 16 && size != 18 && size != 40)
					return;
				formatCode = scan16bits(buffer, 0);
				channels = scan16bits(buffer, 2);
				samplesPerSec = scan32bits(buffer, 4);
				avgBytesPerSec = scan32bits(buffer, 8);
				blockAlign = scan16bits(buffer, 12);
				bitsPerSample = scan16bits(buffer, 14);
				if (formatCode == 0xfffe) // EXTENSIBLE
				{
					if (size != 40)
						return;
						significantBits = scan16bits(buffer, 18);
						// skiping speaker map
						formatCode = scan16bits(buffer, 24); // first two bytes of the GUID
						// the rest of the GUID is fixed, decode it and check it if you wish
				}
			
				this.Ident = chunkType.Fmt;
				this.ByteCount = size;
			}
		}
		class DataChunk : Chunk
		{
			byte[] samples = null;
			///<summary>
			///Create a data chunk
			///<para>
			///The supplied buffer must be correctly sized with zero offset and must be purely for this class
			///</para>
			///<summary>
			///<param name="buffer">source array</param>
			public DataChunk(byte[] buffer)
			{
				this.Ident = chunkType.Data;
				this.ByteCount = buffer.Length;
				samples = buffer;
			}
			public enum SampleStatus { OK, Duff }
			public class Samples
			{
				public SampleStatus Status = SampleStatus.Duff;
				public List<int[]> Channels = new List<int[]>();
    #if false // debugger helper method
				/*
				** Change #if false to #if true to include this
				** Break at end of GetSamples on "return retval"
 				** open immediate window and type retval.DumpLast(16)
				** look in output window for dump of last 16 entries
				*/
				public int DumpLast(int count)
				{
					for (int i = Channels[0].Length - count; i < Channels[0].Length; i++)
						Console.WriteLine(String.Format("{0:X4} {1:X4},{2:X4}", i, Channels[0][i], Channels[1][i]));
					return 0;
				}
    #endif
			}
			/*
			** Return the decoded samples
			*/
			public Samples GetSamples(FmtChunk format)
			{
				Samples retval = new Samples();
				int samplesPerChannel = this.ByteCount / (format.BytesPerSample *  format.Channels);
				int mask = 0;
				int [][] samples = new int [format.Channels][];
				for (int c = 0; c < format.Channels; c++)
					samples[c] = new int[samplesPerChannel];
				
				if (format.BitsPerSample >= 8 && format.BitsPerSample <= 16) // 24+ is left as an excercise
				{
					mask = (int)Math.Floor(Math.Pow(2, format.BitsPerSample) - 1);
			
					int offset = 0, index = 0;
					while (index < samplesPerChannel)
					{
						for (int c = 0; c < format.Channels; c++)
						{
							switch (format.BytesPerSample)
							{
							case 1:
								samples[c][index] = scan8bits(this.samples, offset) & mask;
								break;
							case 2:
								samples[c][index] = scan16bits(this.samples, offset) & mask;
								break;
							}
							offset += format.BytesPerSample;
						}
						++index;
					}
					retval.Channels = new List<int[]>(samples);
					retval.Status = SampleStatus.OK;
				}
				return retval;
			}
		}
		class FactChunk : Chunk
		{
			int samplesPerChannel;
			public int SamplesPerChannel { get { return samplesPerChannel; } }
			public FactChunk(byte[] buffer)
			{
				this.Ident = chunkType.Fact;
				this.ByteCount = buffer.Length;
				if (buffer.Length >= 4)
					samplesPerChannel = scan32bits(buffer);
			}
		}
		class DummyChunk : Chunk
		{
			public DummyChunk(int size, chunkType type = chunkType.Unknown)
			{
				this.Ident = type;
				this.ByteCount = size;
			}
		}
		public RiffLoader(String fileName)
		{
			source = fileName;
			try
			{
				using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
				using (BinaryReader reader = new BinaryReader(fs))
				{
					Chunk c = getChunk(fs, reader);
					if (c.Ident != chunkType.Riff)
					{
						status = RiffStatus.FileError;
						errorMessages.Add(String.Format("Error loading \"{0}\": No valid header"));
					}
					chunks.AddLast(c);
					c = getChunk(fs, reader);
					if (c.Ident != chunkType.Fmt)
					{
						status = RiffStatus.FileError;
						errorMessages.Add(String.Format("Error loading \"{0}\": No format chunk"));
					}
					chunks.AddLast(c);
					/*
					** From now on we just keep scanning to the end of the file
					*/
					while (fs.Position < fs.Length)
					{
						c = getChunk(fs, reader);
						switch (c.Ident)
						{
						case chunkType.Fact:
						case chunkType.Data:
							chunks.AddLast(c);
							break;
						case chunkType.Unknown:
							break; // skip it - don't care what it is
						}
					}
					FmtChunk format = null;
					foreach (var chunk in chunks)
					{
						
						switch(chunk.Ident)
						{
						case chunkType.Fmt:
							format = chunk as FmtChunk;
							break;
						case chunkType.Data:
							if (format != null)
							{
								DataChunk dc = chunk as DataChunk;
								var x = dc.GetSamples(format);
							}
							break;
						}
					}
				}
			}
			catch (Exception e)
			{
				status = RiffStatus.FileError;
				errorMessages.Add(String.Format("Error loading \"{0}\": {1}", e.Message));
			}
		}
		/*
		** Get a chunk of data from the file - knows nothing of the internal format of the chunk.
		*/
		Chunk getChunk(FileStream stream, BinaryReader reader)
		{
			byte[] buffer;
			int size;
			buffer = reader.ReadBytes(8);
			if (buffer.Length == 8)
			{
				String prefix = new String(Encoding.ASCII.GetChars(buffer, 0, 4));
				size = scan32bits(buffer, 4);
				if (size + stream.Position <= stream.Length) // skip if there isn't enough data
				{
					if (String.Compare(prefix, "RIFF") == 0)
					{
						/* 
						** only "WAVE" type is acceptable
						**
						** Don't read size bytes or the entire file will end up in the RIFF chunk
						*/
						if (size >= 4)
						{
							buffer = reader.ReadBytes(4);
							String ident = new String(Encoding.ASCII.GetChars(buffer, 0, 4));
							if (String.CompareOrdinal(ident, "WAVE") == 0)
								return new RiffChunk(size - 4);
						}
					}
					else if (String.Compare(prefix, "fmt ") == 0)
					{
						if (size >= 16)
						{
							buffer = reader.ReadBytes(size);
							if (buffer.Length == size)
								return new FmtChunk(buffer);
						}
					}
					else if (String.Compare(prefix, "fact") == 0)
					{
						if (size >= 4)
						{
							buffer = reader.ReadBytes(4);
							if (buffer.Length == size)
								return new FactChunk(buffer);
						}
					}
					else if (String.Compare(prefix, "data") == 0)
					{
						// assume that there has to be data
						if (size > 0)
						{
							buffer = reader.ReadBytes(size);
							if ((size & 1) != 0) // odd length?
							{
								if (stream.Position < stream.Length)
									reader.ReadByte();
								else
									size = -1; // force an error - there should be a pad byte
							}
							if (buffer.Length == size)
								return new DataChunk(buffer);
						}
					}
					else
					{
						/*
						** there are a number of weird and wonderful block types - assume there has to be data
						*/
						if (size > 0)
						{
							buffer = reader.ReadBytes(size);
							if ((size & 1) != 0) // odd length?
							{
								if (stream.Position < stream.Length)
									reader.ReadByte();
								else
									size = -1; // force an error - there should be a pad byte
							}
							if (buffer.Length == size)
							{
								DummyChunk skip = new DummyChunk(size);
								return skip;
							}
						}
					}
				}
			}
			return new DummyChunk(0, chunkType.Error);
		}
	}
