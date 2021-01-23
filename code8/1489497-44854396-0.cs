    [Fact]
    void test_written_in_notepad()
    {
        List<int> childIds;
        using (var context = CreateInMemoryContext())
        {
            var parent = context.Parents.Include(p => p.Children).FirstOrDefault(p => p.Id == 1);
            childIds = p.Children.Select(c => c.Id).ToList();
            context.Remove(parent);
            context.SaveChanges();
        }
    
        using (var context = CreateInMemoryContext())
        {
            Assert.Empty(context.Children.Where(c => childIds.Contains(c.Id));
        }
    }
