    public JsonResult _BindInvoiceChart()
        {
			List<InvoiceDto> invoices=your_functionToGetInvoices();
            List<ChartsModel> res = new List<ChartsModel>();	
			var currentWeekNumber = DateHelper.GetWeekOfYear(DateTime.Now);
            var firstWeekNumber = currentWeekNumber - 5;
            for (var i = 0; i < 5; i++)
             {
			  ChartsModel chartsModel=new ChartsModel();
              chartsModel.Currentweek=i;
              chartsModel.invoices  = invoices.Where(o =>
                o.InvoiceDate.Year == DateTime.Now.Year &&
                DateHelper.GetWeekOfYear(o.InvoiceDate) == (firstWeekNumber + i)
            ).Sum(o => o.TotalNetCharge);	
			res.Add(chartsModel)
            }	
            return Json(res, JsonRequestBehavior.AllowGet);
        }
