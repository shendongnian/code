    public class CSVMachineRecordStore : IRecordStore<MachineRecord>
    {
        public string GenerateRecord(MachineRecord record)
        {
            var machineRecord = record; //we want to remove the explicit cast
            var strBuilder = new StringBuilder();
            strBuilder.Append(machineRecord.Name);
            strBuilder.Append(machineRecord.ErrorCount);
            return strBuilder.ToString();
        }
    }
