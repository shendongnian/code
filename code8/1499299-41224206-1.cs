            var task = Task.Run(() =>
                {
                    var result = CheckOffice(OfficeIPAddress);
                    this.BeginInvoke((Action)(() =>
                    {
                        if (result == 1)
                        {
                            DGV_OfficeList[4, DGV_OfficeList.CurrentCell.RowIndex].Value = "Connected";
                            //file.copy(sorucefilenamepath, destinationfilenamepath, true); //copy files...
                        }
                        else if (result == 0)
                        {
                            DGV_OfficeList[4, DGV_OfficeList.CurrentCell.RowIndex].Value = "disconnected";
                        }
                    }));
                }
            );
