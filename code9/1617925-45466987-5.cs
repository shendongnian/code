        public ActionResult Index()
        {
            TestM t = new TestM();
            return View(t);
        }
        [HttpPost]
        public ActionResult Index(TestM t)
        {
            if(ModelState.IsValid)
            {
                Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 30);
                byte[] pdfBytes;
                BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
                Font timesBold = new Font(bfTimes, 12, Font.BOLD);
                using (var mem = new MemoryStream())
                {
                    PdfWriter wri = PdfWriter.GetInstance(doc, mem);
                    doc.SetMargins(20, 20, 20, 60);
                    doc.Open();
                    var orderInfoTable = new PdfPTable(2);
                    orderInfoTable.AddCell(new Phrase("First Name:", timesBold));
                    orderInfoTable.AddCell(new Phrase(t.FirstName, timesBold));
                    orderInfoTable.AddCell(new Phrase("Last Name:", timesBold));
                    orderInfoTable.AddCell(new Phrase(t.LastName, timesBold));
                    orderInfoTable.AddCell(new Phrase("Number:", timesBold));
                    orderInfoTable.AddCell(new Phrase(t.Number.ToString(), timesBold));
                    doc.Add(orderInfoTable);
                    doc.Close();
                    pdfBytes = mem.ToArray();
                }
                return File(pdfBytes, "application/pdf", "Weeeeeee_" + DateTime.Now.ToString("_MM-dd-yyyy-mm-ss-tt") + ".pdf");
            }
            else
            {
                return View(t);
            }
            
        }
