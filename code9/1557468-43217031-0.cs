    public class uploaddoc
    {
        private DOCUPLOADED doc;
        public uploaddoc(DOCUPLOADED doc)
        {
            this.doc = doc;
        }
        public bool upload()
        {
            if (doc != null)
            {
                dbcfDataContext dc = new dbcfDataContext();
                dc.DOCUPLOADEDs.InsertOnSubmit(doc);
                //try
                //{
                    dc.SubmitChanges();
                //}
                //catch (Exception ex)
                //{
                    //
                //}
                return true;
            }
            else
                return false;
        }
    }
