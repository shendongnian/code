    public void EditLeavesTemplate(String Id, LeavesTemplate leavestemplate)
            {
                LeavesTemplate z = FindLeavesTemplateById(new ObjectId(Id));
                z.rules = leavestemplate.rules;
                z.max = leavestemplate.max;    
                z.Id = ObjectId.Parse(Id);
                ReplaceOneResult e = context.LeavesTemplates.ReplaceOne(Builders<LeavesTemplate>.Filter.Eq(r => r.Id, z.Id), z, new UpdateOptions() { IsUpsert = true });
                Console.WriteLine(e.IsAcknowledged);
    
            }
