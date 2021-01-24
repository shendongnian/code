            var partitionName = $"name of partition you want to add";
            var newDataPartition = new Partition
            {
                Name = partitionName,
                DataView = DataViewType.Full,
                Source = new QueryPartitionSource
                {
                    DataSource = ds,
                    Query = "sql query here"
                }
            };
            if (!table.Partitions.ContainsName(partitionName))
            {
                table.Partitions.Add(newDataPartition);
            }
            db.Update(UpdateOptions.ExpandFull);
            table.Partitions[partitionName].RequestRefresh(RefreshType.Full);
            table.Partitions["Main"].RequestMerge(new List<Partition> { table.Partitions[partitionName] });
            db.Model.SaveChanges();
