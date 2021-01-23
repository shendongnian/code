    var results = tcs.Skip(searchModel.PageSize * (searchModel.Page - 1))
                        .Take(searchModel.PageSize)
                        .AsEnumerable()
                        .Select(x => new
                        {
                            trackId = x.TrackId,
                            trackName = x.TrackName,
                            category = _weCategoryService.FindAll().Where(y => y.WorkExperience_Track.TrackId == x.TrackId)
                                .Select(y => new {
                                    categoryId = y.CategoryId,
                                    categoryName = y.CategoryName,
                                    skill = _skillsService.FindAll().Where(z => z.CategoryId == y.CategoryId)
                                        .Select(z => new {
                                            skillId = z.SkillId,
                                            skillName = z.SkillName
                                        }).OrderBy(z => SortSkills ? z.skillName : "").OrderByDescending(z => !SortSkills ? z.skillName : "").ToList()
                                }).OrderBy(y => SortCategory ? y.categoryName : "").OrderByDescending(y => !SortCategory ? y.categoryName : "").ToList()
                        }).OrderBy(x => SortTrack ? x.trackName : "").OrderByDescending(x => !SortTrack ? x.trackName : "").ToList();
