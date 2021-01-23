        for (int i = 0; i < dtGridSiparis.RowCount-1; i++)
            {
            order.productID =(dtGridSiparis.Rows[i].Cells[0].Value).ToString();
            order.productName = dtGridSiparis.Rows[i].Cells[1].Value.ToString();
            order.customer = dtGridSiparis.Rows[i].Cells[2].Value.ToString();
            order.faturaNo = dtGridSiparis.Rows[i].Cells[3].Value.ToString();
            order.miktar = dtGridSiparis.Rows[i].Cells[4].Value.ToString();
            order.price = dtGridSiparis.Rows[i].Cells[5].Value.ToString();
            //Save or Insert the record to database
            ctx.siparisDetayys.InsertOnSubmit(order);
            ctx.SubmitChanges();
            }
