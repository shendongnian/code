    foreach (MyDacSourceLines lineadd in
                PXSelectReadonly<MyDacSourceLines,
                Where<........>>>.Select(this, row.RefValueIfweHaveRequiredFields)
                )
            {
               MyLineDac newline = new MyLineDac();
                newline.No = lineadd.No;
                newline.SubElement = lineadd.SubElement;              
                newline = this.Lines.Insert(newline);
            }
