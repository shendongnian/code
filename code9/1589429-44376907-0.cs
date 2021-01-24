            var forwardMap = new Dictionary<int, string>()
                           {
                               {2, searchInputModel.OwnersName},
                               {3, searchInputModel.OwnersAddress},
                               {4, searchInputModel.DescriptionOrLocationOfProp},
                               {5, searchInputModel.VolumeNumber},
                               {6, searchInputModel.SurveyPlanNumber},
                           };
            var query = _entities.LLAttrDatas
                                 .GroupBy(x => x.AttrID)
                                 .Where(x => forwardMap.Keys.Contains(x.AttrID))
                                 .Select(x => new
                                              {
                                                  id = x.AttrID,
                                                  val = x.FirstOrDefault(y => y.ValStr.Contains(forwardMap[x.AttrId]))
                                              });
            //request to server
            var result = query.ToDictionary(x => x.id, x => x.val);
            //now result contains corresponding values
            ViewBag.searchName = result[2];
            ViewBag.searchAddress = result[3];
            ViewBag.searchProperty = result[4];
            ViewBag.searchPropertyVolumeNo = result[5];
            ViewBag.searchPropertyPlanNo = result[6];
