    private static List<Languages> _languages = null;
    
    public static List<Languages> GetLanguages()
    {
        if(_languages == null){
            using (var db = new MCREntities())
            {
                var languages = db.spGetLanguages(0);
                _languages = Mapper.Map<List<Languages>>(languages);
            }
        }
        return _languages;
    }
