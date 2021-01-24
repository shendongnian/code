        public async Task<IActionResult>  Export()
        {
            await Task.Yield();
            //Lets we have object userInfo so we will fill it
            var list = new List<UserInfo>()
            {
                new UserInfo { UserName = "catcher", Age = 18 },
                new UserInfo { UserName = "james", Age = 20 },
            };
            // Then use system.IO.MemeoryStream
            var stream = new MemoryStream();
            //Then generate the Sheet by below code "using OfficeOpenXml;" from EPPlus nugget
            using (var package = new ExcelPackage(stream))
            {
                //name the sheet "Sheet1"
                var workSheet = package.Workbook.Worksheets.Add("Sheet1");
                // simple way
                workSheet.Cells.LoadFromCollection(list, true);
                //// mutual
                //workSheet.Row(1).Height = 20;
                //workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                //workSheet.Row(1).Style.Font.Bold = true;
                //workSheet.Cells[1, 1].Value = "No";
                //workSheet.Cells[1, 2].Value = "Name";
                //workSheet.Cells[1, 3].Value = "Age";
                //int recordIndex = 2;
                //foreach (var item in list)
                //{
                //    workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
                //    workSheet.Cells[recordIndex, 2].Value = item.UserName;
                //    workSheet.Cells[recordIndex, 3].Value = item.Age;
                //    recordIndex++;
                //}
                package.Save();
            }
            stream.Position = 0;
 
            //Name the file which will download
            string excelName = $"UserInfoList-{DateTime.Now.ToString("yyyyMMddHHmmssfff")}.xlsx";
            //Then download 
            return File(stream, "application/octet-stream", excelName);
        }
