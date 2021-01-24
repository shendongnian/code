    DataSet changeSet = new DataSet();
            changeSet.ReadXml("d:\\change.xml");
            DataSet sourceSet = new DataSet();
            sourceSet.ReadXml("d:\\source.xml");
            sourceSet.Tables[0].PrimaryKey = new DataColumn[] { sourceSet.Tables[0].Columns["ParentRandomNo"] };
            changeSet.Tables[0].PrimaryKey = new DataColumn[] { changeSet.Tables[0].Columns["ParentRandomNo"] };
            try
            {
                sourceSet.Merge(changeSet, false);
                sourceSet.AcceptChanges();
                sourceSet.WriteXml("d:\\updated.xml");
            }
            catch (Exception)
            {
                throw;
            }
