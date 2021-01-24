    //assumming Ref_Number is List<string>
        for (int i = 0; i < dtRefNum.Rows.Count; i++ )
         {
             if ((Ref_Number.Where(rn => rn.ToLower().Trim() == dtRefNum.Rows[i].ToString().ToLower().Trim()).Count()) > 0)
              {
                   var refnum = Ref_Number[i].ToString().Trim();
                   var fsdfsdf = dtRefNum.ToString().Trim();
              }
        }
