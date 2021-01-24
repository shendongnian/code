    var result = (from center in ctx.Center
                  select new Center {
                      centerId = center.centerId,
                      customerId = center.customerId,
                      notes = ctx.Note.Where(n => n.centerId == center.centerId)
                                      .Select(n => new Note {
                                          noteId = n.noteId,
                                          centerId = n.centerId,
                                          instruction = ctx.Instruction.FirstOrDedault(i => i.noteId == n.noteId)
                                      })
                  });
