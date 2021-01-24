    // BLOCK WRITE TO MEMORY
                if (type == 0)
                {
                    // Length of line is stored at byte 0, in this case 0x10, or 16 bytes of data
                    length = bytes[0];
                    // Add data from current line to buffer of 256 bytes
                    for (int i = 0; i < length; i++)
                    {
                        // Stuff all bytes from line into buffer of 256 bytes
                        buffer256[byteCounter++] = bytes[4 + i];
                        // Add byte to checksum
                        hexChecksum ^= bytes[4 + i];
                    }
                    // When buffer is full, send block of 256 bytes and checksum, reset variables for next block
                    if (byteCounter >= 255)
                    {
                        // Convert checksum to a byte value
                        hexChecksum = hexChecksum ^ 0xFF;
                        byte csByte = Convert.ToByte(hexChecksum);
                        Byte[] csByte_arr = BitConverter.GetBytes(csByte);
                        
                        // Send byte array
                        _serialPort.Write(buffer256, 0, 256);
                        // For testing
                        // Console.WriteLine("block number [{0}]", ++blockCount);
                        //send checksum
                        _serialPort.Write(csByte_arr, 0, 1);
                        //Receive ACK byte
                        byte_read = _serialPort.ReadByte();
                        Console.WriteLine("block/ACK = [{0}] | {1}", ++blockCount, byte_read);
                        while (byte_read != ACK)
                        {
                            Array.Clear(buffer256, 0, buffer256.Length);
                            hexChecksum = 0;
                            lineCount = 0;
                            // reprocess the previous 16 lines stored in the line buffer
                            for ( int j = 0; j < 16; j++ )
                            {
                                line = lineBuffer[j];
                                line = line.Substring(1, line.Length - 1);
                                var bytesLocal = GetBytesFromByteString(line).ToArray();
                                length = bytesLocal[0];
                                for (int i = 0; i < length; i++)
                                {
                                    buffer256[byteCounter++] = bytesLocal[4 + i];
                                    hexChecksum ^= bytesLocal[4 + i];
                                }
                            }
                            // Convert checksum to a byte value
                            hexChecksum = hexChecksum ^ 0xFF;
                            byte csByteLocal = Convert.ToByte(hexChecksum);
                            Byte[] csByte_arrLocal = BitConverter.GetBytes(csByteLocal);
                            // Send byte array
                            _serialPort.Write(buffer256, 0, 256);
                            //send checksum
                            _serialPort.Write(csByte_arrLocal, 0, 1);
                            //Receive ACK byte
                            byte_read = _serialPort.ReadByte();
                            Console.WriteLine("block/ACK = [{0}] | {1}", ++blockCount, byte_read);
                        }
                        // Clear buffer, reset byte count, clear checksum, set flag to send write cmd/send new addr
                        Array.Clear(buffer256, 0, buffer256.Length);
                        byteCounter = 0;
                        hexChecksum = 0;
                        lineCount = 0;
                        sendAddress = true;
                    }
                }  // end BLOCK WRITE TO MEMORY
