    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    public class Solution
    {
        struct LinePosition
        {
            public long Start;
            public long Length;
    
            public LinePosition(long start, long count)
            {
                Start = start;
                Length = count;
            }
            public override string ToString()
            {
                return string.Format("Start: {0}, Length: {1}", Start, Length);
            }
        }
        class TextFileHasher : IDisposable
        {
            readonly Dictionary<ulong, List<LinePosition>> _hash2LinePositions;
            readonly Stream _stream;
            bool _isDisposed;
    
            public HashSet<ulong> Hashes { get; private set; }
            public string Name { get; private set; }
            public TextFileHasher(string name, Stream stream)
            {
                Name = name;
                _stream = stream;
                _hash2LinePositions = new Dictionary<ulong, List<LinePosition>>();
                Hashes = new HashSet<ulong>();
            }
            public override string ToString()
            {
                return Name;
            }
            public void CalculateFileHash()
            {
                int readByte = -1;
                ulong dummyLineHash = 0;
                // Line start position in file
                long startPosition = 0;
                while ((readByte = _stream.ReadByte()) != -1) {
                    // Read until new line
                    if (readByte == '\r' || readByte == '\n') {
                        // If there was data
                        if (dummyLineHash != 0) {
                            // Add line hash and line position to the dict
                            AddToDictAndHash(dummyLineHash, startPosition, _stream.Position - 1 - startPosition);
                            // Reset line hash
                            dummyLineHash = 0;
                        }
                    }
                    else {
                        // Was it new line ?
                        if (dummyLineHash == 0)
                            startPosition = _stream.Position - 1;
                        // Calculate dummy hash
                        dummyLineHash += (uint)readByte;
                    }
                }
                if (dummyLineHash != 0) {
                    // Add line hash and line position to the dict
                    AddToDictAndHash(dummyLineHash, startPosition, _stream.Position - startPosition);
                    // Reset line hash
                    dummyLineHash = 0;
                }
            }
            public List<LinePosition> GetLinePositions(ulong hash)
            {
                return _hash2LinePositions[hash];
            }
            public List<string> GetDuplicates()
            {
                List<string> duplicates = new List<string>();
    
                foreach (var key in _hash2LinePositions.Keys) {
                    List<LinePosition> linesPos = _hash2LinePositions[key];
                    if (linesPos.Count > 1) {
                        duplicates.AddRange(FindExactDuplicates(linesPos));
                    }
                }
                return duplicates;
            }
            public void Dispose()
            {
                if (_isDisposed)
                    return;
    
                _stream.Dispose();
                _isDisposed = true;
            }
            private void AddToDictAndHash(ulong hash, long start, long count)
            {
                List<LinePosition> linesPosition;
                if (!_hash2LinePositions.TryGetValue(hash, out linesPosition)) {
                    linesPosition = new List<LinePosition>() { new LinePosition(start, count) };
                    _hash2LinePositions.Add(hash, linesPosition);
                }
                else {
                    linesPosition.Add(new LinePosition(start, count));
                }
                Hashes.Add(hash);
            }
            public byte[] GetLineAsByteArray(LinePosition prevPos)
            {
                long len = prevPos.Length;
                byte[] lineBytes = new byte[len];
                _stream.Seek(prevPos.Start, SeekOrigin.Begin);
                _stream.Read(lineBytes, 0, (int)len);
                return lineBytes;
            }
            private List<string> FindExactDuplicates(List<LinePosition> linesPos)
            {
                List<string> duplicates = new List<string>();
                linesPos.Sort((x, y) => x.Length.CompareTo(y.Length));
    
                LinePosition prevPos = linesPos[0];
                for (int i = 1; i < linesPos.Count; i++) {
                    if (prevPos.Length == linesPos[i].Length) {
                        var prevLineArray = GetLineAsByteArray(prevPos);
                        var thisLineArray = GetLineAsByteArray(linesPos[i]);
    
                        if (prevLineArray.SequenceEqual(thisLineArray)) {
                            var line = System.Text.Encoding.Default.GetString(prevLineArray);
                            duplicates.Add(line);
                        }
    #if false
                        string prevLine = System.Text.Encoding.Default.GetString(prevLineArray);
                        string thisLine = System.Text.Encoding.Default.GetString(thisLineArray);
    
                        Console.WriteLine("PrevLine: {0}\r\nThisLine: {1}", prevLine, thisLine);
                        StringBuilder sb = new StringBuilder();
                        sb.Append(prevPos);
                        sb.Append(" is '");
                        sb.Append(prevLine);
                        sb.Append("'. ");
                        sb.AppendLine();
                        sb.Append(linesPos[i]);
                        sb.Append(" is '");
                        sb.Append(thisLine);
                        sb.AppendLine("'. ");
                        sb.Append("Equals => ");
                        sb.Append(prevLine.CompareTo(thisLine) == 0);
                        Console.WriteLine(sb.ToString());
    #endif
    
                    }
                    else {
                        prevPos = linesPos[i];
                    }
                }
                return duplicates;
            }
        }
        public static void Main(String[] args)
        {
            List<TextFileHasher> textFileHashers = new List<TextFileHasher>();
            string text1 = "abc\r\ncba\r\nabc";
            TextFileHasher tfh1 = new TextFileHasher("Text1", new MemoryStream(System.Text.Encoding.Default.GetBytes(text1)));
            tfh1.CalculateFileHash();
            textFileHashers.Add(tfh1);
    
            string text2 = "def\r\ncba\r\nwet";
            TextFileHasher tfh2 = new TextFileHasher("Text2", new MemoryStream(System.Text.Encoding.Default.GetBytes(text2)));
            tfh2.CalculateFileHash();
            textFileHashers.Add(tfh2);
    
            string text3 = "def\r\nbla\r\nwat";
            TextFileHasher tfh3 = new TextFileHasher("Text3", new MemoryStream(System.Text.Encoding.Default.GetBytes(text3)));
            tfh3.CalculateFileHash();
            textFileHashers.Add(tfh3);
    
            List<string> totalDuplicates = new List<string>();
    
            // Two nested loops =>  O(n^2) hell... =)
            for (int i = 0; i < textFileHashers.Count; i++) {
                // If n - number of hashes in textFileHashers[i] and m - number of equal hashes
                // GetDuplicates has O(n*mlogm). Assumption - comparing two strings is O(1) 
                var duplicates = textFileHashers[i].GetDuplicates();
                if (duplicates.Any()) {
                    Console.WriteLine("There is {0} duplicates in the stream ({1})", duplicates.Count, textFileHashers[i].Name);
                    duplicates.ForEach(x => Console.WriteLine(x));
                }
                for (int j = i + 1; j < textFileHashers.Count; j++) {
                    // Get intersection of both Hashes. It should be fast - O(n)
                    var equalHashes = textFileHashers[i].Hashes.Intersect(textFileHashers[j].Hashes);
                    int equalHashesCount = equalHashes.Count();
                    Console.WriteLine("{0} and {1} have {2} equal hashes", textFileHashers[i].Name, textFileHashers[j].Name, equalHashesCount);
    
                    // For each hash which is on both hashes:
                    // Get the lines position in outer textFileHashers
                    // Get the lines position in inner textFileHashers
                    // Check for equality outer and inner strings  
                    foreach (var equalHash in equalHashes) {
                        var tfh1Positions = textFileHashers[i].GetLinePositions(equalHash);
                        var tfh2Positions= textFileHashers[j].GetLinePositions(equalHash);
    
                        for(int k = 0; k < tfh1Positions.Count; k++) {
                            var tfh1Pos = tfh1Positions[k];
                            var tfh1ByteArray = textFileHashers[i].GetLineAsByteArray(tfh1Pos);
                            for (int m = 0; m < tfh2Positions.Count; m++) {
                                var tfh2Pos = tfh2Positions[m];
                                var tfh2ByteArray = textFileHashers[j].GetLineAsByteArray(tfh2Pos);
    
                                if (tfh1ByteArray.SequenceEqual(tfh2ByteArray)) {
                                    var line = System.Text.Encoding.Default.GetString(tfh1ByteArray);
                                    duplicates.Add(line);
                                }
                            }
                        }
                    }
                }
                totalDuplicates.AddRange(duplicates);
            }
    
            Console.WriteLine();
            if (totalDuplicates.Count > 0) {
                Console.WriteLine("Total number of duplicates: {0}", totalDuplicates.Count);
                Console.WriteLine("#######################");
                totalDuplicates.ForEach(x => Console.WriteLine("{0}", x));
                Console.WriteLine("#######################");
            }
            // Free resources
            foreach (var tfh in textFileHashers)
                tfh.Dispose();
        }
    }
