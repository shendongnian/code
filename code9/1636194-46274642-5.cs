        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e) {
            // Draw output for page# PageNumber
            //...
            // Count copies and pages
            e.HasMorePages = true;
            if (--PageCopyCount == 0) {
                PageNumber += 1;
                PageCopyCount = GetNumberOfCopies(PageNumber);
                if (PageCopyCount == 0) e.HasMorePages = false;
            }
        }
