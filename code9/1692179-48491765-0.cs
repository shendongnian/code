    public IEnumerable<Entitys.Member> GetALLMembers()
        {
            IEnumerable<Models.EF_Model.Member> list = new Models.CRUD.Member().Get_AllMemeberRecords();
            List<Entitys.Member> listProduct = new List<Entitys.Member>();
            foreach (var item in list)
            {
                listProduct.Add(new Entitys.Member() { FirstName = item.FirstName,.....});
            }
            return listProduct;
        }
 
