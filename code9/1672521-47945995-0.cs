                if (KeepAlive)
                {
                    LastPing += Time.deltaTime;
                    if (LastPing > 10)
                    {
                        LastPing = 0;
                        CmdPing();
                    }
                }
  
