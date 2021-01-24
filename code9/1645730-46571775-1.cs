         //LAUNCH GUI WITH NEW PATH SEND IF THE USER INTERACT WITH NEW    FILES/DIRECTORIES WITH RIGTH CLICK ON THEM
                //....
                // read the integer value at position 500
                MemoryMappedViewAccessor accessor = mmf.CreateViewAccessor();
                int l = accessor.ReadInt32(0);
                accessor.Flush();
                // print it to the console
                //Console.WriteLine("The memory mapped value is {0}", l);
                if (l != 0)
                {
                    //get path as bytes
                    byte[] Buffer = new byte[l];
                    accessor.ReadArray(4, Buffer, 0, Buffer.Length);
                    accessor.Flush();
                    //convert bytes to string
                    string newPath = ASCIIEncoding.ASCII.GetString(Buffer);
                   // Console.WriteLine("The newPath is " + newPath);
                    if (newPath.CompareTo(LANSharingApp.pathSend) != 0)// it's a new path
                    {
                        LANSharingApp.pathSend = newPath;
                        this.pathBox.Text = newPath;
                        LANSharingApp.umu.clearMetroButtons();
                        base.SetVisibleCore(true);
                        this.WindowState = FormWindowState.Normal;
                    }
                }
