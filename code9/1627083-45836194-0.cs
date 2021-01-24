    public ActionResult PartialView()
    {
       GetDataFromProc proc = new GetDataFromProc();
       DataSet ds = proc.CallProcToDataSet("mySproc");
       return PartialView(ds);
    }
