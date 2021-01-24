    public Service
    {
      private readonly ICache _cache;
      private readonly MyProductDao _myProductDao;
      public Service(ICache cache;)
      {
        _cache = cache;
        _myProductDao = new MyProductDao(_cache);
      }
      public List<MyProduct> GetProductsByCategory(int categoryId)
      {
          /* some code here */
          return _myProductDao.GetProductsByCategory(categoryId);
      }
    }
