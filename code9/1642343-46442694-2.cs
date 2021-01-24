    private void SaveClient()
        {
            using (var context = new PDBContext())
            {
                var client = (from x in context.Clients
                              where x.ID == (Guid) comboClient.SelectedValue
                              select x).FirstOrDefault();
                var project = (from x in context.Projects
                               where x.ID == SelectedProject
                               select x).FirstOrDefault();
                project.Client = client;
                context.Projects.Attach(project);
                context.Entry(project).State = EntityState.Modified;
                context.SaveChanges();
            }
            PopulateClientCombo();
        }
 
