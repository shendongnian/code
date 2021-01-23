        public static void Copy(String SourceFile, String TargetFile)
        {
            FileStream fis = null;
            FileStream fos = null;
                try
                {
                    Console.Write("## Try No. " + a + " : (Write from " + SourceFile + " to " + TargetFile + ")\n");
                    fis = new FileStream(SourceFile, FileMode.Open, FileAccess.ReadWrite);
                    fos = new FileStream(TargetFile, FileMode.Create, FileAccess.ReadWrite);
                    int intbuffer = 5242880;
                    byte[] b = new byte[intbuffer];
                    int i;
                    while ((i = fis.Read(b, 0, intbuffer)) > 0)
                    {
                        fos.Write(b, 0, i);
                    }
                    Console.Write("Writing file : " + TargetFile + " is successful.\n");
                    break;
                }
                catch (Exception e)
                {
                    Console.Write("Writing file : " + TargetFile + " is unsuccessful.\n");
                    Console.Write(e);
                }
                finally
                {
                    if (fis != null)
                    {
                        fis.Close();
                    }
                    if (fos != null)
                    {
                        fos.Close();
                    }
                }
        }
