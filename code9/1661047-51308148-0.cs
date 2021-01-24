      Printer printer = null;
                try
                {
                    printer = new Printer(Series.TM_T82, ModelLang.Ank);
                    printer.Received += Printer_Received;
                    printer.Buffer(order);
                    // Connect to printer through wifi
                    // Find printer from MAC address
                    await printer.ConnectAsync("TCP:64:EB:8C:2C:5B:4F", Printer.PARAM_DEFAULT);
                    await printer.BeginTransactionAsync();
                    // Send data to the printer
                    PrinterStatusInfo status = await printer.GetStatusAsync();
                    if (status.Connection == Connection.True && status.Online == Online.True)
                    {
                        await printer.SendDataAsync(Printer.PARAM_DEFAULT);
                    }
                    // Haven't figure out issue:
                    // If not delayed an ERR_PROCESSING is caught
                    await Task.Delay(1500);
                //
                await printer.EndTransactionAsync();
                await printer.DisconnectAsync();
            }
            catch (Exception ex)
            {
                foreach (PropertyInfo prop in typeof(ErrorStatus).GetProperties())
                {
                    if((int)prop.GetValue(null) == ex.HResult)
                    {
                        throw new Exception(prop.Name);
                    }
                }
                throw new Exception(ex.Message);
            }
            printer.ClearCommandBuffer();
            printer.Received -= Printer_Received;
            printer = null;
            // Form a receipt from given order to the printer data buffer
        public static void Buffer(this Printer printer, Order order)
        {
            // Receipt header
            printer.AddTextAlign(Alignment.Center);
            printer.AddTextSize(2, 1);
            printer.AddText("MALAY PARLOUR\n");
            printer.AddTextSize(Printer.PARAM_DEFAULT, Printer.PARAM_DEFAULT);
            printer.AddText("234 PONSONBY RD, AUCKLAND\n");
            printer.AddText("GST No: 106-338-302\n\n");
            // Order time e.g. 01-01-2017 15:15
            printer.AddText(String.Format("{0:dd}-{0:MM}-{0:yyyy} {0:HH}:{0:mm}\n", order.OrderDate));
            // Print order details
            foreach (OrderDetail od in order.OrderDetails)
            {
                printer.AddTextAlign(Alignment.Left);
                // e.g. 2 *    Seafood Laksa            $16.50
                printer.AddText(String.Format("{0,6} *   {1,-22} {2,10:C2}\n",
                    od.Quantity,
                    od.Product.ProductName,
                    od.UnitPrice * od.Quantity));
                // If item has remarks, add remarks in a new line
                if (!String.IsNullOrEmpty(od.Remarks))
                {
                    printer.AddText("\t" + od.Remarks + "\n");
                }
                printer.AddText("\n");
            }
            printer.AddTextAlign(Alignment.Right);
            // If order has discount, print subtotal and discount
            if (order.Discount != 0)
            {
                printer.AddText(String.Format("Subtotal: ${0:f2}\n", order.Subtotal));
                printer.AddText(String.Format("Discount: {0:P2}\n", order.Discount));
            }
            // Print total. e.g. EftPos: $38.00
            printer.AddTextSize(2, 1);
            printer.AddText(String.Format("{0}: ${1:f2}\n\n", order.Payment, order.Total));
            // Order footer
            printer.AddTextAlign(Alignment.Center);
            printer.AddTextSize(Printer.PARAM_DEFAULT, Printer.PARAM_DEFAULT);
            printer.AddText("www.malayparlour.co.nz\n\n\n");
            // Add a cut
            printer.AddCut(Cut.Default);
        }
     private static void Printer_Received(Printer sender, ReceivedEventArgs args)
        {
            string callbackCode = Enum.GetName(typeof(CallbackCode), args.Code);
            if (callbackCode.Contains("Error"))
            {
                throw new Exception(callbackCode);
            }  
        }
