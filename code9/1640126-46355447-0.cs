    private void ExecuteCalculationsWith<T>()
        where T : MaterialQuantityCalculator, new()
    {
        T calculator = new T();
        calculator.SetDocument(m_doc);
        calculator.CalculateMaterialQuantities();
        calculator.InsertDataTableIntoSqlTable();
    }
    public abstract class MaterialQuantityCalculator
    {
        public abstract void InsertDataTableIntoSqlTable();
        // rest is omitted for clarity
    }
    public class RoofMaterialQuantityCalculator : MaterialQuantityCalculator
    {
        public override void InsertDataTableIntoSqlTable()
        {
            // Content of InsertDataTableintoSQLTableusingSQLBulkCopy() method comes here
        }
        // rest is omitted for clarity
    }
    public class WallMaterialQuantityCalculator : MaterialQuantityCalculator
    {
        public override void InsertDataTableIntoSqlTable()
        {
            // Content of InsertDataTableintoSQLTable_walls() method comes here
        }
        // rest is omitted for clarity
    }
