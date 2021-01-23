    public List<Models.EF_Model.Phone_book> Select(int? _id)
    {
        var Ref_Phone = new Models.EF_Model.Phone_BookEntities1();
        return id.HasValue? Ref_Phone.Phone_book.Where(p => p.Id == _id).ToList():Ref_Phone.Phone_book.ToList();
       
    } 
