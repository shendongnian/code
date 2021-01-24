    using Microsoft.Office.Interop.Access;
    Application access = new Microsoft.Office.Interop.Access.Application();
    access.OpenCurrentDatabase(@"C:\Desktop\MyDB.accdb", false);
    access.DoCmd.OutputTo(AcOutputObjectType.acOutputReport, 
        "Dati", //ReportName
        ".pdf", //OutputType
        @"C:\Desktop\Test.pdf",  //outupuFile
        System.Reflection.Missing.Value,
        System.Reflection.Missing.Value,
        System.Reflection.Missing.Value,
        AcExportQuality.acExportQualityPrint
    );
