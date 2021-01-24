     int uamId = Convert.ToInt32(lblId.Text);
     using (var context = new DemoDbEntities())
        {
            var uamToUpdate = context.tbl_UAM.SingleOrDefault(UpDateuam => UpDateuam.Id == uamId);
            if(uamToUpdate!=null)
            {
                uamToUpdate.MDMRefNumber = tbxMDMRefNum.Text;
                uamToUpdate.SARId = tbxSARId.Text;
                uamToUpdate.DateOfBirthInGreenCard = tbxDoBGreenCard.Text;
                uamToUpdate.DateOfBirthUAM = tbxDoBUAM.Text;
            }
            context.SaveChanges();
        }
