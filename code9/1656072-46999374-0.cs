    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Security.Cryptography;
    using System.Threading.Tasks;
    namespace ConsoleApp1
    {
        class Program
        {
            private const int BufferSizeMib = 64;
            private const int BuffersCount = 4;
            private static object locker = new object();
            private static void Increment(ref int idx)
            {
                idx++;
                if (idx > BuffersCount - 1)
                {
                    idx = 0;
                }
            }
            private static async Task ReadAsync(long toRead, LightBuffer[] buffer, bool allowSimultaneousIo, FileStream sourceStream, int readSize)
            {
                var blockNum = 0;
                var readIdx = 0;
                while (toRead > 0)
                {
                    var lightBuffer = buffer[readIdx];
                    lightBuffer.WriteDone.WaitOne();
                    lightBuffer.WriteDone.Reset();
                    lightBuffer.Number = ++blockNum;
                    if (allowSimultaneousIo)
                    {
                        lightBuffer.Length = await sourceStream.ReadAsync(lightBuffer.Data, 0, readSize);
                        if (lightBuffer.Length == 0)
                        {
                            throw null;
                        }
                    }
                    else
                    {
                        lock (locker)
                        {
                            lightBuffer.Length = sourceStream.Read(lightBuffer.Data, 0, readSize);
                            if (lightBuffer.Length == 0)
                            {
                                Debugger.Break();
                                throw null;
                            }
                        }
                    }
                    toRead -= lightBuffer.Length;
                    lightBuffer.IsFinal = toRead == 0;
                    lightBuffer.DataReady.Set();
                    Increment(ref readIdx);
                }
            }
            public static async Task<byte[]> WriteAsync(LightBuffer[] buffer, bool allowSimultaneousIo, Action<double> progressCallback, long length, int readBufferSize, string destinationPath)
            {
                using (HashAlgorithm sha = SHA1.Create())
                using (var destinationStream = new FileStream(destinationPath, FileMode.CreateNew, FileAccess.Write, FileShare.None, readBufferSize, FileOptions.WriteThrough))
                {
                    var writeIdx = 0;
                    var run = true;
                    var writeDone = 0L;
                    while (run)
                    {
                        var lightBuffer = buffer[writeIdx];
                        lightBuffer.DataReady.WaitOne();
                        lightBuffer.DataReady.Reset();
                        var hashTask = Task.Factory.StartNew(() =>
                        {
                            if (lightBuffer.IsFinal)
                            {
                                sha.TransformFinalBlock(lightBuffer.Data, 0, lightBuffer.Length);
                                run = false;
                            }
                            else
                                sha.TransformBlock(lightBuffer.Data, 0, lightBuffer.Length, null, 0);
                        }, TaskCreationOptions.LongRunning);
                        if (allowSimultaneousIo)
                        {
                            await destinationStream.WriteAsync(lightBuffer.Data, 0, lightBuffer.Length);
                        }
                        else
                        {
                            lock (locker)
                            {
                                destinationStream.Write(lightBuffer.Data, 0, lightBuffer.Length);
                            }
                        }
                        await hashTask;
                        writeDone += lightBuffer.Length;
                        lightBuffer.WriteDone.Set();
                        progressCallback?.BeginInvoke((double)writeDone / length * 100d, ar => { }, null);
                        Increment(ref writeIdx);
                    }
                    return sha.Hash;
                }
            }
            private static async Task<byte[]> CopyUnbufferedAndComputeHashAsync(string filePath, string destinationPath, Action<double> progressCallback, bool allowSimultaneousIo)
            {
                const FileOptions fileFlagNoBuffering = (FileOptions)0x20000000;
                const FileOptions fileOptions = fileFlagNoBuffering | FileOptions.SequentialScan;
                const int chunkSize = BufferSizeMib * 1024 * 1024;
                var readBufferSize = chunkSize;
                readBufferSize += ((readBufferSize + 1023) & ~1023) - readBufferSize;
                using (var sourceStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, readBufferSize, fileOptions))
                {
                    var length = sourceStream.Length;
                    var toRead = length;
                    var readSize = Convert.ToInt32(Math.Min(chunkSize, length));
                    var buffer = new LightBuffer[BuffersCount];
                    for (var i = 0; i < BuffersCount; ++i)
                    {
                        buffer[i] = new LightBuffer(readSize) { Number = -1 * i };
                    }
                    // execute tasks
                    var readTask = ReadAsync(toRead, buffer, allowSimultaneousIo, sourceStream, readSize);
                    var writeTask = WriteAsync(buffer, allowSimultaneousIo, progressCallback, length, readBufferSize, destinationPath);
                    // await tasks
                    await Task.WhenAll(readTask, writeTask);
                    // return hash
                    return writeTask.Result;
                }
            }
        }
    }
