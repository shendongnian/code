    public static string GenerarExcel(DirectoryInfo outputDir)
    {
        string conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        DataSet dsRemito = new DataSet();
        DataTable dtCons = new DataTable();
        using (SqlConnection sqlCon = new SqlConnection(conn))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                try
                {//SP for sql query
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "SACBUS_CONSUL_SOLICITUDEXIST";
                    cmd.Parameters.AddWithValue("@ID_CONSULTA", 66);
                    //66 wil be a variable, this is only for my tests
                    cmd.Connection = sqlCon;
                    sqlCon.Open();
                    SqlDataAdapter dapC = new SqlDataAdapter(cmd);
                    dapC.Fill(dsRemito);
                }
                catch (Exception sqlex)
                {
                    throw sqlex;
                }
            }
        }
        FileInfo newFile = new FileInfo(outputDir.FullName + @"\Sample1.xlsx");
        
        if (newFile.Exists)
        {
            newFile.Delete();
            newFile = new FileInfo(outputDir.FullName + @"\Sample1.xlsx"); //preparar nombre archivo
        }
        using (ExcelPackage package = new ExcelPackage(newFile))
        {
            // Agregar hoja a worbook
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Envios");
            // Header
            worksheet.Cells[1, 3].Value = "SISTEMA DE GESTIÓN DE CALIDAD ISO 9001:2008";
            worksheet.Cells[2, 3].Value = "PEDIDO DE CONSULTA A BODEGA";
            worksheet.Cells[1, 5].Value = "Código:";
            worksheet.Cells[1, 6].Value = "FOR-PCV-COM-SAC-PEBOD-02  ";
            worksheet.Cells[2, 5, 2, 6].Merge = true;
            // Estilo del Encabezado
            using (var range = worksheet.Cells[1, 1, 1, 5]) // De la celda 1,1 a la 1,5
            {
                range.Style.Font.Bold = true; // Negrita
                range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid; // Solido lleno
                range.Style.Fill.BackgroundColor.SetColor(Color.DarkBlue); //Background
                range.Style.Font.Color.SetColor(Color.White);// Font color
            }
            // Pie de Pagina
            // lineas en la cuadricula
            worksheet.Cells["A5:E5"].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            worksheet.Cells["A5:E5"].Style.Font.Bold = true; // estilo del pie de pagina
           
            //Formatos
            //Formato Numerico
            worksheet.Cells["C2:C5"].Style.Numberformat.Format = "#,##0";   // Formato Entero
            worksheet.Cells["D2:E5"].Style.Numberformat.Format = "#,##0.00";    // Formato Decimal
                   worksheet.Cells["A2:A4"].Style.Numberformat.Format = "@"; //Formato texto
            worksheet.Cells.AutoFitColumns(0); //AutoAjustar celdas
          
            // Numero de pagina + total de paginas a la derecha del pie de pagina
            worksheet.HeaderFooter.OddFooter.RightAlignedText = string.Format("Pagina {0} of {1}", ExcelHeaderFooter.PageNumber, ExcelHeaderFooter.NumberOfPages);
            // Nombre de la hoja al centro del pie de pagina
            worksheet.HeaderFooter.OddFooter.CenteredText = ExcelHeaderFooter.SheetName;
            // Ruta a la izquierda del pie de pagina
            worksheet.HeaderFooter.OddFooter.LeftAlignedText = ExcelHeaderFooter.FilePath + ExcelHeaderFooter.FileName;
            //System.Drawing.Image img = System.Drawing.Image.FromFile(@"C:\temporal\asp\ExcelLibrary\LockersLogo.jpg");
            System.Drawing.Image img = System.Drawing.Image.FromFile(HttpContext.Current.Server.MapPath("~/image/LockersLogo.jpg"));
            ExcelPicture pic = worksheet.Drawings.AddPicture("Sample", img);
            pic.SetPosition(0, 0, 6, 0);
            pic.SetSize(150, 75);
            //Items consultados
            var registros = 0;
            for (int i = 0; i < dsRemito.Tables[0].Rows.Count; i++)
            {
                worksheet.Cells[8 + i, 1].Value = dsRemito.Tables[0].Rows[i]["CAJA_CODIGO"];
                worksheet.Cells[8 + i, 2].Value = dsRemito.Tables[0].Rows[i]["CAJA_NUMERO"];
                worksheet.Cells[8 + i, 3].Value = dsRemito.Tables[0].Rows[i]["CAJA_CONTENIDO_NUMERO"];
                worksheet.Cells[8 + i, 4].Value = dsRemito.Tables[0].Rows[i]["ITEM"];
                registros = i;
            }
            package.Save(); //guardar workbook
        }
        return newFile.FullName;
    }
    protected void DownloadFile()
    {
        string rutaUsr = "~/" + "Files/";
        string filePath = rutaUsr + "Sample1" + ".xlsx";
        Response.ContentType = ContentType;
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
        Response.WriteFile(filePath);
        Response.End();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //DirectoryInfo outputDir = new DirectoryInfo(@"C:\temporal\asp\ExcelLibrary");
            DirectoryInfo outputDir = new DirectoryInfo(HttpContext.Current.Server.MapPath("~/Files/"));
            GenerarExcel(outputDir);
            DownloadFile();
        }
        
        catch (Exception ex)
        {
            Console.WriteLine("Error: {0}", ex.Message);
        }
    }
