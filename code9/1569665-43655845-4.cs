    public class DiskDeliveryBO {
        readonly ICommonCalls CommonCalls;
        readonly IDiskDeliveryDAO diskDeliveryDAO;
        readonly IFileSystem File;
        public DiskDeliveryBO(ICommonCalls CommonCalls, IDiskDeliveryDAO diskDeliveryDAO, IFileSystem File) {
            this.CommonCalls = CommonCalls;
            this.diskDeliveryDAO = diskDeliveryDAO;
            this.File = File;
        }
        public int TrackPublicationChangesOnCDS() {
            var resultFlag = -1;
            try {
                string pubUpdateFileCDSPath = CommonCalls.PubUpdateFileCDSPath;
                string pubUpdateFileLocalPath = CommonCalls.PubUpdateFileLocalPath;
                if (File.Exists(pubUpdateFileCDSPath))
                    File.Copy(pubUpdateFileCDSPath, pubUpdateFileLocalPath, true);
                if (File.Exists(pubUpdateFileLocalPath)) {
                    string[] pubRecords = File.ReadAllLines(pubUpdateFileLocalPath);
                    var pubRecordsExceptToday = pubRecords.Where(p => !p.Trim().EndsWith(DateTime.Now.ToString("dd/MM/yy"))).ToList();
                    resultFlag = diskDeliveryDAO.TrackPublicationChangesOnCDS(pubRecordsExceptToday);
                    File.WriteAllText(pubUpdateFileLocalPath, string.Empty);
                    string[] pubRecordsCDS = File.ReadAllLines(pubUpdateFileCDSPath);
                    var pubRecordsTodayCDS = pubRecordsCDS.Where(p => p.Trim().EndsWith(DateTime.Now.ToString("dd/MM/yy"))).ToList();
                    File.WriteAllLines(pubUpdateFileCDSPath, pubRecordsTodayCDS);
                }
                return resultFlag;
            } catch (Exception) {
                return -1;
            }
        }
    }
