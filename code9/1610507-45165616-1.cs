    var builder = new StringBuilder();
    builder.AppendLine("<onbase-certificate>");
    builder.AppendLine(f2.richTextBox1.Text);
    builder.AppendLine("<licenses>");
    for (int i = 0; i < Convert.ToInt32(gridView1.DataRowCount); i++)
            {
                builder.AppendLine("<license>");
                builder.AppendLine("<name>![CDATA[" + gridView1.GetRowCellValue(i, "productname").ToString() + "]</name>");
               builder.AppendLine("<code sig=\"1\">");
               builder.AppendLine(gridView1.GetRowCellValue(i, "count").ToString(););
               builder.AppendLine("</code>");
                // ...
                
               builder.AppendLine("</license>");
            }
    builder.AppendLine("</licenses>");
    builder.AppendLine("</onbase-certificate>");
    File.WriteAllText(saveFileDialog1.FileName, builder.ToString());
