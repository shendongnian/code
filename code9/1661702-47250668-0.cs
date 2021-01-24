        public ActionResult GetExcelFile(int id)
            {
                var entityPermission = AuthenticationManager.GetEntityPermission(PermissionEntity.Events, PermissionLevel.AllRecords);
                if (entityPermission == null || !entityPermission.AllowRead)
                    return Json(new RequestResult(RequestCode.Unauthorized), JsonRequestBehavior.AllowGet);
        
                try
                {
                    using (var serviceManager = new ServiceManager())
                    {
                        // Get object model
                        var firstTableObj = serviceManager.GetDataForExcel(id);
                        StringBuilder sb = new StringBuilder();
                        sb.Append("<table border=`" + "1px" + "`b>");
                        sb.Append("<tr>");
                        // ... appending other strings and data
                        sb.Append("</table>");
        
                        // Return FileResult
                        byte[] byteArray = Encoding.UTF8.GetBytes(sb.ToString());
                        return File(new MemoryStream(byteArray, 0, byteArray.Length), "application/octet-stream", $"{firstTableObj.CurrentDate}.xlsx");                   
                    }
                }
                catch (Exception ex)
                {
                    //Do something except returning Json response
                }
    }
     
