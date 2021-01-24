    var query =
      from vm in dataContext.VotingMatrices
      where vm.EventId == eventId
      where vm.Deleted == 0
      from vmm in vm.VotingMatrixMembers
      where vmm.Deleted == 0
      group vmm by new { vm.EventId, vmm.VotingMatrixId } into g
      select new
      {
        g.Key.EventId,
        g.Key.VotingMatrixId,
        PersonAcceptedCount: g.Select(x => Convert.ToInt32(x.IsAccepted)).Sum()
      } into resultRow
      order by resultRow.PersonAcceptedCount descending
      select resultRow;
    
    var row = query.FirstOrDefault();
