    public FileResult Edit(SpiseKopunTable model)
        {
            bool b = repository.PutSpiseKopun(model);
            DateTime d = new DateTime(1980, 1, 1);
            DateTime.TryParse(model.Dato.ToString(), out d);
            int c = new int();
            int.TryParse(model.ID.ToString(), out c);
            using (MemoryStream stream = new System.IO.MemoryStream())
            {
                var numberOfVouchers = 3;
                string voucherTable = String.Format(@"<table><tbody><tr><td>GL:{0}
                </td></ tr >< tr >
                < td > Service:{1}
                </ td ></ tr >< tr >
                < td > Dato:{2}
                </ td ></ tr >< tr >
                < td > Pris:{3}
                </ td ></ tr >< tr >
                < td > Kommentar:{4}
                </ td ></ tr><tr>
                <td> ID:{5}
                </ td ></ tr ></ tbody ></ table >",
                                model.GL,
                                model.Service,
                                d.ToString("dd-MM-yyyy"),
                                model.Pris,
                                model.Kommentar,
                                c.ToString()
                                );
                StringReader sr = new StringReader(
                new StringBuilder().Insert(0, voucherTable, numberOfVouchers).ToString());
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                pdfDoc.Close();
                return File(stream.ToArray(), "application/pdf", "Airgreenland-vouchers.pdf");
            }
