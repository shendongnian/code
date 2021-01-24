                ModelName objModel = new ModelName();
                List<Levels> LevelList = GetAllLevels();
                objModel.lstTypes = LevelList.Select(y => new SelectListItem()
                {
                    Value = y.LevelId.ToString(),
                    Text = y.LevelName.ToString()
                });
             return View(objModel);
