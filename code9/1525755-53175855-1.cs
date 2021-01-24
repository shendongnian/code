    // Set settings, check status, print, etc.
            if (setPrintLanguage(statusConnection) && checkPrinterStatus(statusConnection))
            {
                int labelCount = Integer.parseInt(SGD.GET("odometer.total_label_count", statusConnection));
                // Send Print Job (1 label)
                String zplData = "^XA^FO20,20^A0N,25,25^FDThis is a ZPL test.^FS^XZ";
                printerConnection.write(zplData.getBytes());
             
                if (postPrintCheckPrinterStatus(statusConnection))
                {
                    int newLabelCount = Integer.parseInt(SGD.GET("odometer.total_label_count", statusConnection));
                    if (newLabelCount == labelCount + 1)
                    {
                        System.out.println("Print Successful.");
                    }
                }
                //else reprint?
            }  
