    Typology typology = dbContext.Typologies.Where(t => t.Id == projectDTO.TypologyId).First();
                //projectContext.Typology = typology;
    
    //dbContext.Projects.Add(projectContext);
    typology.Projects.Add(new Project() {...});
    dbContext.SaveChanges();
