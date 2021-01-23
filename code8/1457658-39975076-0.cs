    public class GenderBAL
    {
        public List<Genders> GetGenderList() 
        {
            List<Genders> gender = null;
            Genders itm = null;
            using (GenderTableAdapter adp = new GenderTableAdapter())
            {
                using (DAL.dstLookup.GenderDataTable tbl = adp.GetGenderDataList())
                {
                    if(tbl.Count>0)
                    {
                        gender = new List<Genders>();
                        foreach(var row in tbl)
                        {
                            itm = new Genders();
                            itm.GenderId = row.GenderId;
                            itm.Gender = row.Gender;
                            gender.Add(itm);
                        }
                    }
                }
            }
            return gender;
        }
    }
