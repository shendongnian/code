        public class StateObject
        {
            public long connectionNumber = -1;
            public Socket workSocket { get; set; }
            public byte[] buffer { get; set; }
            public int fifoCount { get; set; }
            public string terminID { get; set; }
            public DateTime trackTime { get; set; }
            public DateTime currTime { get; set; }
            public byte[] longitude { get; set; }
            public byte[] lattitude { get; set; }
            public byte speed { get; set; }
        }
                                        case PROTOCOL_NUMBER.LOGIN_MESSAGE:
                                            serialNumber.CopyTo(loginResponse, 4);
                                            sendCRC = crc_bytes(loginResponse.Skip(2).Take(loginResponse.Length - 6).ToArray());
                                            loginResponse[loginResponse.Length - 4] = (byte)((sendCRC >> 8) & 0xFF);
                                            loginResponse[loginResponse.Length - 3] = (byte)((sendCRC) & 0xFF);
                                            //
                                            string terminalID = Encoding.ASCII.GetString(receiveMessage.Skip(4).Take(messageLength - 5).ToArray());
                                            byteState.Value.terminID = terminalID;
                                            Console.WriteLine("Received good login message from Serial Number : '{0}', Terminal ID = '{1}'", "0x" + serialNumber[0].ToString("X2") + serialNumber[1].ToString("X2"), terminalID);
                                            Console.WriteLine("Send Message : '{0}'", BytesToString(loginResponse));
                                            Send(state.workSocket, loginResponse);
                                            StateObjectDB stateObjectDB = new StateObjectDB() { terminalID = terminalID, date = DateTime.Now };
                                            WriteDBAsync.ReadWriteFifo(WriteDBAsync.Mode.WRITE, stateObjectDB);
                                            Console.WriteLine("Wrote to database");
                                            break;
                                        case PROTOCOL_NUMBER.LOCATION_DATA:
                                            year = receiveMessage[4];
                                            month = receiveMessage[5];
                                            day = receiveMessage[6];
                                            hour = receiveMessage[7];
                                            minute = receiveMessage[8];
                                            second = receiveMessage[9];
                                            date = new DateTime(2000 + year, month, day, hour, minute, second);
                                            byteState.Value.trackTime = date;
                                            byteState.Value.currTime = DateTime.Now;
                                            if (byteState.Value.lattitude == null) byteState.Value.lattitude = new byte[4];
                                            Array.Copy(receiveMessage, 11, byteState.Value.lattitude, 0, 4);
                                            if (byteState.Value.longitude == null) byteState.Value.longitude  = new byte[4];
                                            Array.Copy(receiveMessage, 15, byteState.Value.lattitude, 0, 4);
                                            byteState.Value.speed = receiveMessage[19];
                                            Console.WriteLine("Received good location message from Serial Number '{0}', Time = '{1}'", "0x" + serialNumber[0].ToString("X2") + serialNumber[1].ToString("X2"), date.ToLongDateString());
                                            break;
