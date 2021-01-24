                                   switch (protocolNumber)
                                    {
                                        case PROTOCOL_NUMBER.LOGIN_MESSAGE:
                                            serialNumber.CopyTo(loginResponse, 4);
                                            sendCRC = crc_bytes(loginResponse.Skip(2).Take(loginResponse.Length - 6).ToArray());
                                            loginResponse[loginResponse.Length - 4] = (byte)((sendCRC >> 8) & 0xFF);
                                            loginResponse[loginResponse.Length - 3] = (byte)((sendCRC) & 0xFF);
                                            //
                                            string IMEI = Encoding.ASCII.GetString(receiveMessage.Skip(4).Take(messageLength - 5).ToArray());
                                            byteState.Value.IMEI = IMEI;
                                            Console.WriteLine("Received good login message from Serial Number : '{0}', Terminal ID = '{1}'", "0x" + serialNumber[0].ToString("X2") + serialNumber[1].ToString("X2"), IMEI);
                                            Console.WriteLine("Send Message : '{0}'", BytesToString(loginResponse));
                                            Send(state.workSocket, loginResponse);
                                            WriteDBMessageLogin  loginMessage = new  WriteDBMessageLogin() { message = DATABASE_MESSAGE_TYPE.LOGIN, IMEI = IMEI, date = DateTime.Now };
                                            WriteDBAsync.ReadWriteFifo(WriteDBAsync.Mode.WRITE, loginMessage);
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
                                            WriteDBMessageLocation locationMessage = new WriteDBMessageLocation(); 
                                            locationMessage.trackTime = date;
                                            locationMessage.currTime = DateTime.Now;
                                            locationMessage.lattitude = new byte[4];
                                            Array.Copy(receiveMessage, 11, locationMessage.lattitude, 0, 4);
                                            locationMessage.longitude = new byte[4];
                                            Array.Copy(receiveMessage, 15, locationMessage.longitude, 0, 4);
                                            
                                            locationMessage.speed = receiveMessage[19];
                                            locationMessage.courseStatus = new byte[2];
                                            Array.Copy(receiveMessage, 20, locationMessage.courseStatus, 0, 2);
                                            WriteDBAsync.ReadWriteFifo(WriteDBAsync.Mode.WRITE, locationMessage);
                                            Console.WriteLine("Received good location message from Serial Number '{0}', Time = '{1}'", "0x" + serialNumber[0].ToString("X2") + serialNumber[1].ToString("X2"), date.ToLongDateString());
                                            break;
                                        case PROTOCOL_NUMBER.ALARM_DATA:
                                            year = receiveMessage[4];
                                            month = receiveMessage[5];
                                            day = receiveMessage[6];
                                            hour = receiveMessage[7];
                                            minute = receiveMessage[8];
                                            second = receiveMessage[9];
                                            date = new DateTime(2000 + year, month, day, hour, minute, second);
                                            Console.WriteLine("Received good alarm message from Serial Number '{0}', Time = '{1}'", "0x" + serialNumber[0].ToString("X2") + serialNumber[1].ToString("X2"), date.ToLongDateString());
                                            int packetLen = alarmResponse.Length - 5;
                                            alarmResponse[2] = (byte)(packetLen & 0xFF);
                                            serialNumber.CopyTo(alarmResponse, packetLen - 1);
                                            sendCRC = crc_bytes(alarmResponse.Skip(2).Take(packetLen - 1).ToArray());
                                            alarmResponse[packetLen + 1] = (byte)((sendCRC >> 8) & 0xFF);
                                            alarmResponse[packetLen + 2] = (byte)((sendCRC) & 0xFF);
                                            Console.WriteLine("Send Message : '{0}'", BytesToString(alarmResponse));
                                            Send(state.workSocket, alarmResponse);
                                            break;
                                    } //end switch
