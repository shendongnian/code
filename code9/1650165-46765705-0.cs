    private void AddFooterData(Section section) {
          
            var rightFooterSection = new Paragraph {
                Format = { Alignment = ParagraphAlignment.Right }
            };
            rightFooterSection.AddText("Prepared By Eng: " + _preparedBy);
            var rightFooterPagePar = new Paragraph {
                 Format = { Alignment = ParagraphAlignment.Right }
             };
            rightFooterPagePar.AddText("Page ");
            rightFooterPagePar.AddPageField();
            rightFooterPagePar.AddText("/");
            rightFooterPagePar.AddNumPagesField();
            var date = DateTime.Now.ToString("yyyy/MM/dd");
            var leftSection = new Paragraph {
                Format = { Alignment = ParagraphAlignment.Left }
            };
            var leftDateSection = new Paragraph {
                Format = { Alignment = ParagraphAlignment.Left }
            };
            leftSection.AddText("Approved By: " + _approvedBy);
            leftDateSection.AddText(date);
            var footerTable = section.Footers.Primary.AddTable();
            var col1 = footerTable.AddColumn();
            col1.Width = "5.5in";
            var col2 = footerTable.AddColumn();
            col2.Width = "5.5in";
            var row1 = footerTable.AddRow();
            row1[0].Add(leftSection);
            row1[1].Add(rightFooterSection);
            row1.Borders.Bottom.Visible = true;
            row1.Borders.Bottom.Width = "0.10cm";
            var row2 = footerTable.AddRow();
            row2[0].Add(leftDateSection);
            row2[1].Add(rightFooterPagePar);
