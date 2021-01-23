      var total = 0;
                    do
                    {
                        int read = soc.EndReceive(soc.BeginReceive(theSocPkt.dataBuffer, 0,
                            theSocPkt.dataBuffer.Length,
                            SocketFlags.None,
                            pfnWorkerCallBack,
                            theSocPkt));
                        if (read == 0)
                        {
                        }
                        total += read;
                    } while (total != 4000);
