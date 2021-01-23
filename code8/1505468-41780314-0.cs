    public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var characterCraft = new CharacterCraftViewModel()
            {
                CharNames = await db.Database.SqlQuery<CharacterCraftNamesListViewModel>(sql: "GetCharacterCraftCharacterNameProfessionName @p0", parameters: new object[] { id }).FirstAsync(),
                CraftListA = await db.Database.SqlQuery<CharacterCraftCraftListViewModel>(sql: "GetCharacterCraftRank @p0, @p1", parameters: new object[] { id, 1 }).ToListAsync(),
                CraftListB = await db.Database.SqlQuery<CharacterCraftCraftListViewModel>(sql: "GetCharacterCraftRank @p0, @p1", parameters: new object[] { id, 2 }).ToListAsync(),
                CraftListC = await db.Database.SqlQuery<CharacterCraftCraftListViewModel>(sql: "GetCharacterCraftRank @p0, @p1", parameters: new object[] { id, 3 }).ToListAsync()
            };
            if (characterCraft == null)
            {
                return HttpNotFound();
            }
            return View(characterCraft);
        }
