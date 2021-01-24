    private void _xlCall_Click(object sender, EventArgs e)  
    {  
                Excels.Application oExcel = new Excels.Application();  
                Excels.Workbooks oBooks = oExcel.Workbooks;  
                string tabName=cbSelectTable.Text;  
                object oMissing = System.Reflection.Missing.Value;  
                Excels._Workbook oBook = null;  
                oExcel.Visible = false;  
    string srcPath = "C:\\Desktop\\file.xlsm";  
    oBook = oBooks.Open(srcPath, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing);  
    string fNames;  
                    fNames = oExcel.Run(tabName); //fNames is going to get the value   
    if(fNames=="Yes")  
    {  
                    oExcel.Visible = true;    
    }  
    else  
    {  
    }  
    } 
