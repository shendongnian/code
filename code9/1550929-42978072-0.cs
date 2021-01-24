        string password = "9quali52ty3";
        // Convert the string into a byte[].
        byte[] asciiBytes = Encoding.ASCII.GetBytes(password);
        string compiledBytes = System.Text.Encoding.UTF8.GetString(asciiBytes);
        int convertedBytes = int.Parse(compiledBytes);
        m_PdfDocument.InitSecurityHandler(convertedBytes);
        m_PdfDocument.GetSecurityHandler();
