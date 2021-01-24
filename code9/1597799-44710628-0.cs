    var member = await db.Member.Include(x => x.Gender).Include(x => x.Case.CaseNumber)
                .FirstOrDefaultAsync(x => x.Relationship.Code == "PA" && x.CaseId == cid && x.Deleted == false);
            var relationshipsdd = db.RelationshipDD;
            var model = new CaseCrossReferenceFromRelationshipViewModel()
            {
                MemberId = member?.MemberId,
                FirstName = member?.FirstName,
                MiddleName = member?.MiddleName,
                LastName = member?.LastName,
                Gender = member?.Gender.Code,
                CaseNumber = member?.Case.CaseNumber?.Number == null
                    ? null
                    : member.Case.CaseNumber?.CaseNumberPrefix + "-" + member.Case.CaseNumber?.Number,
                CaseId = member?.CaseId,
                ToCases = await db.CaseCrossReference
                    .Where(x => (x.From_Case == cid || x.To_Case == cid)
                                && x.Deleted == false)
                    .Select(o => new CaseCrossReferenceToRelationshipViewModel()
                    {
                        CaseIdFrom = o.From_Case,
                        CaseIdTo = o.To_Case,
                        CaseCrossReferenceId = o.CaseCrossReferenceId,
                        LivingTogether = o.LivingTogether,
                        Gender = o.Relationship.Gender.Code,
                        Split = o.Split,
                        SplitDate = o.SplitDate,
                        SplitReason = o.SplitReason,
                        Type = o.Type.Definition,
                        RelationshipDefinition = o.Relationship.Definition,
                        Relationship = o.Relationship.Id
                    }).ToListAsync()
            };
            foreach (var cases in model.ToCases)
            {
                // Check for any reverse relationships/Case Number
                var reference = await db.CaseCrossReference.Include(x => x.Relationship)
                    .Include(x => x.Case2.CaseNumber).Include(x => x.Case1.CaseNumber)
                    .FirstOrDefaultAsync(m => m.From_Case == cases.CaseIdFrom && m.To_Case == cases.CaseIdTo);
                if (cases.CaseIdFrom == cid)
                {
                    member = await db.Member.Include(x => x.Gender)
                        .FirstOrDefaultAsync(x => x.Relationship.Code == "PA" && x.CaseId == cases.CaseIdTo &&
                                                  x.Deleted == false);
                    cases.CaseIdFrom = cases.CaseIdTo;
                    cases.CaseNumber = reference.Case2.CaseNumber?.Number == null
                        ? null
                        : reference.Case2.CaseNumber.CaseNumberPrefix + "-" + reference.Case2.CaseNumber.Number;
                    cases.FirstName = member.FirstName;
                    cases.MiddleName = member.MiddleName;
                    cases.LastName = member.LastName;
                    if (member.Gender.Code == "M")
                    {
                        cases.RelationshipDefinition = await relationshipsdd
                            .Where(r => r.Id == reference.Relationship.Id)
                            .Select(r => r.MaleReverseRelationshipDefinition).FirstOrDefaultAsync();
                    }
                    else
                    {
                        cases.RelationshipDefinition = await relationshipsdd
                            .Where(r => r.Id == reference.Relationship.Id)
                            .Select(r => r.FemaleReverseRelationshipDefinition).FirstOrDefaultAsync();
                    }
                }
                else
                {
                    member = await db.Member.Include(x => x.Gender)
                        .FirstOrDefaultAsync(x => x.Relationship.Code == "PA" && x.CaseId == cases.CaseIdFrom &&
                                                  x.Deleted == false);
                    cases.CaseIdTo = cases.CaseIdFrom;
                    cases.CaseNumber = reference.Case1.CaseNumber?.Number == null
                        ? null
                        : reference.Case1.CaseNumber.CaseNumberPrefix + "-" + reference.Case1.CaseNumber.Number;
                    cases.FirstName = member.FirstName;
                    cases.MiddleName = member.MiddleName;
                    cases.LastName = member.LastName;
                }
            }
            return View(model);
