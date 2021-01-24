    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using JetBrains.Annotations;
    
    namespace Whatever
    {
        public sealed class LoggedBinaryReader : BinaryReader
        {
            [UsedImplicitly]
            public LoggedBinaryReader([NotNull] Stream input) : this(input, Encoding.Default)
            {
            }
    
            public LoggedBinaryReader(Stream input, Encoding encoding, bool leaveOpen = true) : base(input, encoding, leaveOpen)
            {
                Journal = new LoggedBinaryReaderJournal(this);
            }
    
            private LoggedBinaryReaderJournal Journal { get; }
    
            public override int Read()
            {
                using (new LoggedBinaryReaderScope(Journal))
                    return base.Read();
            }
    
            public override int Read(byte[] buffer, int index, int count)
            {
                using (new LoggedBinaryReaderScope(Journal))
                    return base.Read(buffer, index, count);
            }
    
            public override int Read(char[] buffer, int index, int count)
            {
                using (new LoggedBinaryReaderScope(Journal))
                    return base.Read(buffer, index, count);
            }
    
            public override char ReadChar()
            {
                using (new LoggedBinaryReaderScope(Journal))
                    return base.ReadChar();
            }
    
            public override char[] ReadChars(int count)
            {
                using (new LoggedBinaryReaderScope(Journal))
                    return base.ReadChars(count);
            }
    
            public override string ReadString()
            {
                using (new LoggedBinaryReaderScope(Journal))
                    return base.ReadString();
            }
    
            public override bool ReadBoolean()
            {
                using (new LoggedBinaryReaderScope(Journal))
                    return base.ReadBoolean();
            }
    
            public override byte ReadByte()
            {
                using (new LoggedBinaryReaderScope(Journal))
                    return base.ReadByte();
            }
    
            public override sbyte ReadSByte()
            {
                using (new LoggedBinaryReaderScope(Journal))
                    return base.ReadSByte();
            }
    
            public override short ReadInt16()
            {
                using (new LoggedBinaryReaderScope(Journal))
                    return base.ReadInt16();
            }
    
            public override int ReadInt32()
            {
                using (new LoggedBinaryReaderScope(Journal))
                    return base.ReadInt32();
            }
    
            public override long ReadInt64()
            {
                using (new LoggedBinaryReaderScope(Journal))
                    return base.ReadInt64();
            }
    
            public override ushort ReadUInt16()
            {
                using (new LoggedBinaryReaderScope(Journal))
                    return base.ReadUInt16();
            }
    
            public override uint ReadUInt32()
            {
                using (new LoggedBinaryReaderScope(Journal))
                    return base.ReadUInt32();
            }
    
            public override ulong ReadUInt64()
            {
                using (new LoggedBinaryReaderScope(Journal))
                    return base.ReadUInt64();
            }
    
            public override byte[] ReadBytes(int count)
            {
                using (new LoggedBinaryReaderScope(Journal))
                    return base.ReadBytes(count);
            }
    
            public override float ReadSingle()
            {
                using (new LoggedBinaryReaderScope(Journal))
                    return base.ReadSingle();
            }
    
            public override double ReadDouble()
            {
                using (new LoggedBinaryReaderScope(Journal))
                    return base.ReadDouble();
            }
    
            public override decimal ReadDecimal()
            {
                using (new LoggedBinaryReaderScope(Journal))
                    return base.ReadDecimal();
            }
    
            public IEnumerable<LoggedBinaryReaderRegion> GetRegionsRead()
            {
                return Journal.GetRegions();
            }
    
            public IEnumerable<LoggedBinaryReaderRegion> GetRegionsUnread()
            {
                var blocks = new LinkedList<LoggedBinaryReaderRegion>(Journal.GetRegions());
    
                var curr = blocks.First;
    
                // nothing explored
                if (curr == null)
                {
                    yield return new LoggedBinaryReaderRegion(0, BaseStream.Length);
                    yield break;
                }
    
                // account for beginning of file
                if (curr.Value.Position > 0)
                    yield return new LoggedBinaryReaderRegion(0, curr.Value.Position);
    
                // in-between
                while (true)
                {
                    var next = curr.Next;
                    if (next == null)
                        break;
    
                    var position = curr.Value.Position + curr.Value.Length;
                    var length = next.Value.Position - position;
    
                    if (length > 0)
                        yield return new LoggedBinaryReaderRegion(position, length);
    
                    curr = next;
                }
    
                // account for end of file
                if (curr.Value.Position + curr.Value.Length < BaseStream.Length)
                    yield return new LoggedBinaryReaderRegion(
                        curr.Value.Position + curr.Value.Length,
                        BaseStream.Length - (curr.Value.Position + curr.Value.Length));
            }
        }
    
        public struct LoggedBinaryReaderRegion
        {
            internal LoggedBinaryReaderRegion(long position, long length)
            {
                Position = position;
                Length = length;
            }
    
            public long Position { get; }
    
            public long Length { get; }
    
            public override string ToString()
            {
                return $"{nameof(Position)}: {Position}, {nameof(Length)}: {Length}";
            }
        }
    
        internal class LoggedBinaryReaderJournal
        {
            internal LoggedBinaryReaderJournal([NotNull] LoggedBinaryReader reader)
            {
                if (reader == null)
                    throw new ArgumentNullException(nameof(reader));
    
                Reader = reader;
                Regions = new List<LoggedBinaryReaderRegion>();
            }
    
            private long Position { get; set; }
    
            private LoggedBinaryReader Reader { get; }
    
            private List<LoggedBinaryReaderRegion> Regions { get; }
    
            internal void StartLogging()
            {
                Position = Reader.BaseStream.Position;
            }
    
            internal void StopLogging()
            {
                var length = Reader.BaseStream.Position - Position;
                var region = new LoggedBinaryReaderRegion(Position, length);
                Regions.Add(region);
            }
    
            public IEnumerable<LoggedBinaryReaderRegion> GetRegions()
            {
                return Regions.OrderBy(s => s.Position);
            }
        }
    
        internal struct LoggedBinaryReaderScope : IDisposable
        {
            private LoggedBinaryReaderJournal Journal { get; }
    
            internal LoggedBinaryReaderScope(LoggedBinaryReaderJournal journal)
            {
                Journal = journal;
                Journal.StartLogging();
            }
    
            public void Dispose()
            {
                Journal.StopLogging();
            }
        }
    }
