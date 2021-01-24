    using System;
    using System.Collections.Concurrent;
    using System.IO;
    using System.Threading.Tasks;
    namespace ConsoleApp1
    {
        public class Program
        {
            private const int writeBufferSize = 10;
            private const int hashBufferSize = 10;
            private const int blockSize = 512;
            private DataBlock ReadData(FileStream sourceStream, int count)
            {
                var buffer = new byte[count];
                var len = sourceStream.Read(buffer, 0, count);
                return new DataBlock { Buffer = buffer, Length = len };
            }
            private Task GetWriteTask(BlockingCollection<DataBlock> collection, string destinationPath)
            {
                return Task.Run(() =>
                {
                    using (var destinationStream = new FileStream(destinationPath, FileMode.CreateNew))
                    {
                        while (!collection.IsCompleted)
                        {
                            var dataBlock = collection.Take();
                            destinationStream.Write(dataBlock.Buffer, 0, dataBlock.Length);
                        }
                    }
                });
            }
            private Task GetHashTask(BlockingCollection<DataBlock> collection)
            {
                return Task.Run(() =>
                {
                    // Here you have to call the hashing algorithm
                    throw new NotImplementedException();
                });
            }
            private void ProcessData(string sourcePath, string destinationPath)
            {
                // initialize blocking collections
                BlockingCollection<DataBlock> writeBuffer = new BlockingCollection<DataBlock>(writeBufferSize);
                BlockingCollection<DataBlock> hashBuffer = new BlockingCollection<DataBlock>(hashBufferSize);
                // create tasks for writing and hashing
                var writeTask = GetWriteTask(writeBuffer, destinationPath);
                var hashTask = GetHashTask(hashBuffer);
                using (var sourceStream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read, FileShare.Read, blockSize))
                {
                    while (true)
                    {
                        // read data block
                        DataBlock dataBlock = ReadData(sourceStream, blockSize);
                        if (dataBlock.Length == 0)
                        {
                            // reading is finished
                            writeBuffer.CompleteAdding();
                            hashBuffer.CompleteAdding();
                            break;
                        }
                        else
                        {
                            // add data to collections
                            writeBuffer.Add(dataBlock);
                            hashBuffer.Add(dataBlock);
                        }
                    }
                }
                // wait until writing and hashing is finished
                Task.WaitAll(writeTask, hashTask);
            }
        }
    }
