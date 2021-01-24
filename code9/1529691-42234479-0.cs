    public static void PrintingQueue(Queue<byte[]> printQueue, string printer, int copies)
        {
            Parallel.ForEach(printQueue, (currentFile) =>
            {
                currentFile = printQueue.Dequeue();
                PrintFormPdfData(currentFile, printer, copies);
            });
        }
        private static void PrintFormPdfData(byte[] pdfFormBytes, string printer, int copies)
        {
            var fileName = Path.GetTempFileName();
            using (var file = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite))
            {
                file.Write(pdfFormBytes, 0, pdfFormBytes.Length);
                using (GhostscriptProcessor processor = new GhostscriptProcessor())
                {
                    List<string> switches = new List<string>();
                    switches.Add("-empty");
                    switches.Add("-dPrinted");
                    switches.Add("-dBATCH");
                    switches.Add("-dPDFFitPage");
                    switches.Add("-dNOPAUSE");
                    switches.Add("-dNOSAFER");
                    switches.Add("-dNumRenderingThreads=3");
                    switches.Add("-dNumCopies=1");
                    switches.Add("-sOutputFile=%printer%" + printer);
                    switches.Add("-sDEVICE=mswinpr2");
                    switches.Add(fileName);
                    try
                    {
                        processor.StartProcessing(switches.ToArray(), null);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    file.Close();
                }
                File.Delete(fileName);
            }
        }
