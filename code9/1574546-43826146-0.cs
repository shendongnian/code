	public class CompressedString
	{
		private class Segment
		{
			public Segment(int count, CompressedString value)
			{
				Count = count;
				Value = value;
			}
			public int Count { get; set; }
			public CompressedString Value { get; set; }
		}
		private List<Segment> segments = new List<Segment>();
		private string uncompressible;
		private CompressedString(){}
		public static CompressedString Compress(string s)
		{
			var compressed = new CompressedString();
            // longest possible repeating substring is half the length of the
            // string, so try that first and work down to shorter lengths
			for(int len = s.Length/2; len > 0; len--)
			{
                // look for the substring at each possible index
				for(int i = 0; i < s.Length - len - 1; i++)
				{
					var sub = s.Substring(i, len);
					int count = 1;
                    // look for repeats of the substring immediately after it.
					for(int j = i + len; j <= s.Length - len; j += len)
					{
                        // increase the count of times the substring is found
                        // or stop looking when it doesn't match
						if(sub == s.Substring(j, len))
						{
							count++;
						}
						else
						{
							break;
						}
					}
                    // if we found repeats then handle the substring before the 
                    // repeats, the repeast, and everything after.
					if(count > 1)
					{
                        // if anything is before the repeats then add it to the
                        // segments with a count of one and compress it.
						if (i > 0)
						{
							compressed.segments.Add(new Segment(1, Compress(s.Substring(0, i))));
						}
                        // Add the repeats to the segments with the found count
                        // and compress it.
						compressed.segments.Add(new Segment(count, Compress(sub)));
                        // if anything is after the repeats then add it to the
                        // segments with a count of one and compress it.
						if (s.Length - (count * len) > i)
						{
							compressed.segments.Add(new Segment(1, Compress(s.Substring(i + (count * len)))));
						}
                        // We're done compressing so break this loop and the
                        // outer by setting len to 0.
						len = 0;
						break;
					}
				}
			}
            // If we failed to find any repeating substrings then we just have
            // a single uncompressible string.
			if (!compressed.segments.Any())
			{
				compressed.uncompressible = s;
			}
            // Reduce the the compression for something like "2(2(ab))" to "4(ab)"
			compressed.Reduce();
			return compressed;
		}
		private void Reduce()
		{
            // Attempt to reduce each segment.
			foreach(var seg in segments)
			{
				seg.Value.Reduce();
                // If there is only one sub segment then we can reduce it.
				if(seg.Value.segments.Count == 1)
				{
					var subSeg = seg.Value.segments[0];
					seg.Value = subSeg.Value;
					seg.Count *= subSeg.Count;
				}
			}
		}
		public override string ToString()
		{
			if(segments.Any())
			{
				StringBuilder builder = new StringBuilder();
				foreach(var seg in segments)
				{
					if (seg.Count == 1)
						builder.Append(seg.Value.ToString());
					else
					{
						builder.Append(seg.Count).Append("(").Append(seg.Value.ToString()).Append(")");
					}
				}
				return builder.ToString();
			}
			return uncompressible;
		}
	}
