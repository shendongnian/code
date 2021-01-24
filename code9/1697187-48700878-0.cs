        public async Task<MyNewViewModel> queryResolutionDetailsById(int id, string username)
       {
         var result1 = _context.Table1.Where(p => p.CorpActionId == id);
         var result2 = _context.Table2.Where(p => p.CorpActionId == id && p.ElectedBy == username);
         IEnumerable<MyNewViewModel> viewmodel1 = AutoMapper.Mapper.Map<IEnumerable<MyNewViewModel>>(result1);
         // Even though syntactically correct, this line will overwrite
         // the values from the line above
         viewmodel1 = AutoMapper.Mapper.Map<IEnumerable<MyNewViewModel>>(result2);
         return viewmodel1;
       }
