        /// Method that return a new Tablix formatted for our file Report_Dynamic.rdlc
        /// </summary>
        /// <param name="datos">DataTable complete from Select statement</param>
        /// <returns>New Tablix with all columns and rows from your DataTable ☺</returns>
        private string CrearTablaDeReporteXML(DataTable datos)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<Tablix Name='Tablix1'>");
            #region TablixBody
            sb.AppendLine("  <TablixBody>");
            #region Tablixcolumns
            sb.AppendLine("    <TablixColumns>");
            for (int i = 0; i < datos.Columns.Count; i++)
            {
                //Columns
                sb.AppendLine("      <TablixColumn>");
                sb.AppendLine("        <Width>1.06in</Width>");
                sb.AppendLine("      </TablixColumn>");
            }
            sb.AppendLine("    </TablixColumns>");
            #endregion
            #region TablixRows
            sb.AppendLine("    <TablixRows>");
            #region Row header
            sb.AppendLine("<TablixRow>");
            sb.AppendLine("<Height>0.25in</Height>");
            sb.AppendLine("<TablixCells>");
            int numeroTexto = 1000;
            for (int i = 0; i < datos.Columns.Count; i++)
            {
                sb.AppendLine("<TablixCell>");
                sb.AppendLine("<CellContents>");
                sb.AppendLine(string.Format("<Textbox Name='Textbox{0}'><CanGrow>true</CanGrow><KeepTogether>true</KeepTogether><Paragraphs><Paragraph><TextRuns><TextRun><Value>{1}</Value><Style><FontSize>8pt</FontSize><FontWeight>Bold</FontWeight></Style></TextRun></TextRuns><Style/></Paragraph></Paragraphs><rd:DefaultName>Textbox1</rd:DefaultName><Style><Border><Color>LightGrey</Color><Style>Solid</Style></Border><BackgroundColor>LightGrey</BackgroundColor><PaddingLeft>2pt</PaddingLeft><PaddingRight>2pt</PaddingRight><PaddingTop>2pt</PaddingTop><PaddingBottom>2pt</PaddingBottom></Style></Textbox>", numeroTexto, datos.Columns[i]));                
                sb.AppendLine("</CellContents>");
                sb.AppendLine("</TablixCell>");
                numeroTexto++;
            }
            sb.AppendLine("</TablixCells>");
            sb.AppendLine("</TablixRow>");
            #endregion
            #endregion
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                //Rows
                sb.AppendLine("      <TablixRow>");
                sb.AppendLine("        <Height>0.25in</Height>");
                sb.AppendLine("        <TablixCells>");
                for (int j = 0; j < datos.Columns.Count; j++)
                {
                    sb.AppendLine("          <TablixCell>");
                    sb.AppendLine("            <CellContents>");
                    sb.AppendLine(string.Format("              <Textbox Name='Textbox{0}'><CanGrow>true</CanGrow><KeepTogether>true</KeepTogether><Paragraphs><Paragraph><TextRuns><TextRun><Value>{1}</Value><Style><FontSize>8pt</FontSize></Style></TextRun></TextRuns><Style/></Paragraph></Paragraphs><rd:DefaultName>Textbox2</rd:DefaultName><Style><Border><Color>LightGrey</Color><Style>Solid</Style></Border><PaddingLeft>2pt</PaddingLeft><PaddingRight>2pt</PaddingRight><PaddingTop>2pt</PaddingTop><PaddingBottom>2pt</PaddingBottom></Style></Textbox>", numeroTexto, datos.Rows[i].ItemArray[j].ToString().Replace("&", "")));
                    sb.AppendLine("            </CellContents>");
                    sb.AppendLine("          </TablixCell>");
                    numeroTexto++;
                }
                sb.AppendLine("        </TablixCells>");
                sb.AppendLine("      </TablixRow>");                
            }
            sb.AppendLine("    </TablixRows>");
            sb.AppendLine("  </TablixBody>");
            #endregion
            sb.AppendLine("      <TablixColumnHierarchy>");
            sb.AppendLine("<TablixMembers>");
            for (int i = 0; i < datos.Columns.Count; i++)
                sb.AppendLine("<TablixMember />");
            sb.AppendLine("</TablixMembers>");
            sb.AppendLine("</TablixColumnHierarchy>");
            sb.AppendLine("      <TablixRowHierarchy>");
            sb.AppendLine("<TablixMembers>");
            sb.AppendLine("<TablixMember><KeepWithGroup>After</KeepWithGroup></TablixMember>");
            for (int i = 0; i < datos.Rows.Count; i++)
                sb.AppendLine(string.Format("<TablixMember />"));
            sb.AppendLine("</TablixMembers>");
            sb.AppendLine("</TablixRowHierarchy>");
            sb.AppendLine("      <Top>0.05556in</Top>");
            sb.AppendLine("      <Left>0.11458in</Left>");
            sb.AppendLine("      <Height>1.25in</Height>");
            sb.AppendLine(string.Format("      <Width>8in</Width>"));
            sb.AppendLine("      <Style>");
            sb.AppendLine("        <Border>");
            sb.AppendLine("          <Style>None</Style>");
            sb.AppendLine("        </Border>");
            sb.AppendLine("      </Style>");
            sb.AppendLine("      </Tablix>");
            return sb.ToString();
        }
