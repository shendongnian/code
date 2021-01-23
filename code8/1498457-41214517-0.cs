        protected override void Generate(AddColumnOperation addColumnOperation)
        {
            //add the column
            base.Generate(addColumnOperation);
            //alter the column
            this.Generate(new AlterColumnOperation(addColumnOperation.Table, addColumnOperation.Column, false));
        }
        protected override void Generate(CreateTableOperation createTableOperation)
        {
            //add the column
            base.Generate(createTableOperation);
            //alter the column
            foreach(ColumnModel column in createTableOperation.Columns)
            {
                this.Generate(new AlterColumnOperation(createTableOperation.Name, column, false));
            }
        }
