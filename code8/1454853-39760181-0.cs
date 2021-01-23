        private void btnCodificarArquivos_Click(object sender, EventArgs e)
        {
            Encoding ANSI = Encoding.GetEncoding(1252);
            byte[] hash = ANSI.GetBytes(@"laki#~~2p3fijo3ij881*2f-|-  a`asso`wpeofi#jdJD92jd9jdfjl2@38d8d");
            string directory;
            string originalExtension;
            string finalExtension;
            string debugFileName;
            TextWriter debugFile = null;
            if (cbxCodificar.Checked)
            {
                originalExtension = "mp3";
                finalExtension = "mpc";
            }
            else
            {
                originalExtension = "mpc";
                finalExtension = "mp3";
            }
            directory = txbFrase.Text.Trim();
            if (!Directory.Exists(directory))
                throw new Exception("Directory does not exist => " + directory);
            var files = Directory.GetFiles(directory, "*." + originalExtension);
            foreach (var file in files)
            {
                using (FileStream streamFile = new FileStream(file, FileMode.Open, FileAccess.ReadWrite))
                {
                    using (MemoryStream codedMemory = new MemoryStream())
                    {
                        debugFileName = Path.ChangeExtension(file, ".txt");
                        if (cbxDebugar.Checked)
                        {
                            debugFile = new StreamWriter(debugFileName);
                        }
                        streamFile.CopyTo(codedMemory);
                        byte[] fileArray = codedMemory.ToArray();
                        byte[] output = new byte[fileArray.Length];
                        for (int i = 0; i < fileArray.Length; i++)
                        {
                            output[i] = (byte)(fileArray[i] ^ ~hash[(i + 1) % hash.Length]);
                            if (cbxDebugar.Checked)
                                debugFile.WriteLine(output[i]);
                        }
                        using (MemoryStream memoryCodificado = new MemoryStream(output))
                        {
                            string fileDestination = Path.ChangeExtension(file, "." + finalExtension);
                            if (File.Exists(fileDestination))
                                File.Delete(fileDestination);
                            using (FileStream arquivoFinal = new FileStream(fileDestination, FileMode.Create, FileAccess.ReadWrite))
                            {
                                memoryCodificado.Position = 0;
                                memoryCodificado.CopyTo(arquivoFinal);
                            }
                        }
                        if (cbxDebugar.Checked)
                        {
                            debugFile.Flush();
                            debugFile.Close();
                            debugFile = null;
                        }
                    }
                }
            }
        }
