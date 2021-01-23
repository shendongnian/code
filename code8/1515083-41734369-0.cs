            // remove hospitals that are not currently assigned to someone
            hospitalsToCheck.RemoveAll(
                h =>
                {
                    return
                        !currentAssignments.Exists(
                            a => a.AssignmentGroup.AssignedUnitIds.Intersect(h.Units.Select(u => u.UnitId)).Any());
                });
