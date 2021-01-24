    ToCases       = await db.CaseCrossReference
                            .Include(x => x.Relationship)
                            .Include(x => x.Type)
                            .Where(x => (x.From_Case == cid || x.To_Case == cid)
                                             && x.Deleted == false)
                            .Select(o => new CaseCrossReferenceToRelationshipViewModel()
                    {
                        CaseId = o.From_Case,
                        CaseCrossReferenceId = o.CaseCrossReferenceId,
                        CaseNumber = o.Case2.CaseNumber?.Number == null ? null : o.Case2.CaseNumber.CaseNumberPrefix + "-" + o.Case2.CaseNumber.Number,
                        LivingTogether = o.LivingTogether,
                        Split = o.Split,
                        SplitDate = o.SplitDate,
                        SplitReason = o.SplitReason,
                        Type = o.Type.Definition,
                        RelationshipDefinition = o.Relationship.Definition
    
                    }).ToListAsync();
