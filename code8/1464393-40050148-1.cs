    var result = (from section in db.getSections
                  join question in db.getQuestion 
                  on section.SectionID == questions.SectionID into sectionQuestions
                  select new Section
                  {
                      Prop1 = section.Prop1,
                      Prop2 = section.prop2,
                      Questions = sectionQuestions
                  });
