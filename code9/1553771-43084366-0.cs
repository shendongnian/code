            var firstItem = (
                            from vmm in db.VotingMatrixMember
                            join vm in db.VotingMatrix on vmm.VotingMatrixID equals vm.ID
                            where vm.EventID =  "abbe3077-24de-45d8-ac04-13dba97c1567"
                                                    && vm.Deleted = 0
                                                    && vmm.Deleted = 0
                            group new {vm, vmm} by new {vm.EventID, vmm.VotingMatrixID} into gr
                            select new
                            {
                                EventID = gr.Key.EventID,
                                VotingMatrixID = gr.Key.VotingMatrixID,
                                PersonAcceptedCount = gr.Sum(x => Convert.ToInt32(x.IsAccepted))
                            } 
                            into groupedItem 
                            orderby  groupedItem.PersonAcceptedCount descending 
                            select groupedItem                            
                             ).FirstOrDefault();
