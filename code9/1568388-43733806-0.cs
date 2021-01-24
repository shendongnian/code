      public async Task<IActionResult> CreatePlatePdf(string dto)
        {
            try
            {
                List<int> dto= JsonConvert.DeserializeObject<List<int>>(dto);
                MemoryStream ms = new MemoryStream();
                Document doc = new Document(PageSize.A4, 30f, 30f, 30f, 30f);
                PdfWriter writer = PdfWriter.GetInstance(doc, ms);
                doc.Open();
                await this.CreateDoc(dto, doc);
                doc.Close();
                writer.Flush();
                byte[] byteInfo = ms.ToArray();
                ms.Write(byteInfo, 0, byteInfo.Length);
                ms.Seek(0, SeekOrigin.Begin);
                return this.File(ms, "application/pdf", fileName.pdf);
            }
    }
