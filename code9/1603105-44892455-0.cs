    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Excel = Microsoft.Office.Interop.Excel;
    using System.Data;
    using System.Data.OleDb;
    DataTable dt;
    // fill table data in dt here 
    ...
    
    // export DataTable to excel
    // save excel file without ever making it visible if filepath is given
    // don't save excel file, just make it visible if no filepath is given
    dt.ExportToExcel(ExcelFilePath);
