    unitOfWork.PersonSkillsRepository.GetAll()
              .Where(p => p.IdCategory == ids.IdCategory 
                       || p.IdSubCategory == ids.IdSubCategory)
              .GroupBy(p => p.PersonId)
              .Where(g => g.Any(p => p.IdCategory == ids.IdCategory) 
                       && g.Any(p => p.IdSubCategory == ids.IdSubCategory))
              .Select(g => g.Key) 
