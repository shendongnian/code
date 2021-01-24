    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;
    namespace ConsoleApplication23
    {
        class Program
        {
            static void Main(string[] args)
            {
                int[] lengths = { 45, 200, 1600, 3500, 13000 };
                foreach (int len in lengths)
                {
                    int totalLen = len;
                    do
                    {
                        int processLen = totalLen > 8000 ? 8000 : totalLen;
                        totalLen -= 8000;
                        int numChunks = 8;
                        int chunkSize = 0;
                        for (; (numChunks > 0) && (chunkSize < 50); numChunks--)
                        {
                            chunkSize = processLen / numChunks;
                        }
                        chunkSize = 50 * (chunkSize / 50);
                        int lastChunk = processLen - (chunkSize * numChunks);
                        Console.WriteLine(" Number of Chunks '{0}', Chunk Size = '{1}', Total Size = '{2}'", numChunks, chunkSize, (numChunks * chunkSize) + lastChunk);
                    } while (totalLen > 0);
                    
                }
            }
        }
    }
