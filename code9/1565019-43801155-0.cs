        public List<MakerInfo> GetMakersInfo()
        {
            SMDStatusServiceClient requester = null;
            try
            {
                requester = new SMDStatusServiceClient();
                var response = requester.Request("//MachineStatus[@MachineType='MAKER']/ShiftStatus");
                return ParseMakersInfo(response);
            }
            catch (Exception e)
            {
                FXEventLogger.Instance().AddLog(EventLogEntryType.Error, e);
                return null;
            }
            finally
            {
                requester.Close();
                GC.SuppressFinalize(this);
            }
        }
        private List<MakerInfo> ParseMakersInfo(string shiftStatesXml)
        {
            using (var sr = new StringReader(shiftStatesXml))
            {
                var serializer = new XmlSerializer(typeof(List<MakerInfo>), new XmlRootAttribute("result"));
                var _makersInfo = (List<MakerInfo>) serializer.Deserialize(sr);
                sr.Dispose();
                
                return _makersInfo;
            }
        }
    }`
