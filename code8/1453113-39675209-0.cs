     if(partnersDataSet.Tables[0].Rows.Count>0)   
     {
        if(!string.IsNullOrEmpty(partnersDataSet.AI_PARTNERS[0].SURNAME))
        {
        if (partnersDataSet.AI_PARTNERS[0].SURNAME != System.DBNull.Value))
         {
        _partnerInfo.Surname =partnersDataSet.AI_PARTNERS[0].SURNAME;
         }
        }       
     }
