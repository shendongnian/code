    [HttpPost]
    public void saveRecords(Dictionary<string, object> payload)
    {    
        var _records = this.IRepository.records.Where(w => /*some conditions*/);
    
        foreach (var kvp in payload)
        {
            var _record = _records.Where(w => w.key == kvp.Key).FirstOrDefault();
            if (_record != null)
            {
                AutoMapper.Map(kvp.Value, _record);
            }
        }
    
        this.IRepository.SaveChanges();
    }
