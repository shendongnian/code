    foreach (var item in projects)
            {// Update projects to closed.
                item.Project.IsOpen = false;
                item.Project.DateClosed = DateTime.Now;
            }
