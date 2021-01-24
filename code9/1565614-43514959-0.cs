        private async Task<InvalidInvoiceViewModel> ValidateInsertedDataInRawTables(string uploadPath, long batchId)
        {
            var direcotryPath = Path.Combine(uploadPath, batchId.ToString());
            var allFiles = Directory.GetFiles(direcotryPath);
            var invoiceRawList = new List<InvoiceRaw>();
            var invoiceDetailRawList = new List<InvoiceDetailRaw>();
            await Task.Run(() =>
            {
                foreach(var file in allFiles)
                {
                    var fileName = Path.GetFileNameWithoutExtension(file);
                    switch (fileName)
                    {
                        case "invoice":
                            invoiceRawList = await ValidateInsertedDataInRawTablesForInvoiceAsync(batchId);
                            break;
                        case "invoicedetails":
                            invoiceDetailRawList = await ValidateInsertedDataInRawTablesForInvoiceDetailAsync(batchId);
                            break;
                    }
                }
            });
            var invalidInvoiceViewModel = new InvalidInvoiceViewModel
            {
                InvoiceRawList = invoiceRawList,
                InvoiceDetailRawList = invoiceDetailRawList
            };
            return invalidInvoiceViewModel;
        }
