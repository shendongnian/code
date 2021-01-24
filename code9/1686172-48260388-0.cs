     var ProjectAssignments = new ProjectAssignment[] {
         new ProjectAssignment {
             ProjectID = Projects.Single( i => i.ID == 1).ID, // ID == "1"
             WorkerID = Workers.Single( i => i.ID == 1).ID,
         },
         new ProjectAssignment {
             ProjectID = Projects.Single( i => i.ID == 1).ID, // ID == "1", again
             WorkerID = Workers.Single( i => i.ID == 2).ID,
         },
         // ...
     }
