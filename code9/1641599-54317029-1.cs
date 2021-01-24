                    while (streamReader.Peek() >= 0)
                    {
                        if (success == 0)
                        {
                            _line = streamReader.ReadLine();
                            setConnectionStatus("Status: Checking WiFi network using passphrase " + _line);
                            if (await checkWifiPassword(_line) == true)
                            {
                                success = 1;
                                setConnectionStatus("SUCCESS: Password successfully identified as " + _line);
                                firstAdapter.Disconnect();
                                var msg = new MessageDialog(connectionStatus.Text);
                                await msg.ShowAsync();
                            }
                            else
                            {
                                success = 0;
                                setConnectionStatus("FAIL: Password " + _line + "is incorrect. Checking next password...");
                            }
                        }
                    }
