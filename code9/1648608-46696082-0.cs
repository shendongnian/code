    public interface IRecordStore<T> where T : IRecord
    {
        string GenerateRecord(T record);
    }
    public class CSVMachineRecordStore : IRecordStore<MachineRecord>
    {
        public string GenerateRecord(MachineRecord record)
        {
            var machineRecord = record;
            var strBuilder = new StringBuilder();
            strBuilder.Append(machineRecord.Name);
            strBuilder.Append(machineRecord.ErrorCount);
            return strBuilder.ToString();
        }
    }
