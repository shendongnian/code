                    StringBuilder formatted;
                    using (var sha1 = new SHA1Managed())
                    {
                        //var bytePass = ReadFully(passStream);
                        var bytePass = passStream.ToArray();
                        var hash = sha1.ComputeHash(bytePass);
                        formatted = new StringBuilder(2 * hash.Length);
                        foreach (var b in hash)
                        {
                            formatted.AppendFormat("{0:X2}", b);
                        }
                    }
                    manifest.passjson = formatted.ToString().ToLower();
