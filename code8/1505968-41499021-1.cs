    using System;
    using System.IO;
    using System.Net;
    using FluentFTP;
    
    namespace Examples {
        public class OpenWriteExample {
            public static void OpenWrite() {
                using (FtpClient conn = new FtpClient()) {
                    conn.Host = "localhost";
                    conn.Credentials = new NetworkCredential("ftptest", "ftptest");
    
                    using (Stream ostream = conn.OpenWrite("01-03-2017/John, Doe S. M.D/file.wav")) {
                        try {
                            // istream.Position is incremented accordingly to the writes you perform
                        }
                        finally {
                            ostream.Close();
                        }
                    }
                }
            }
        }
    }
