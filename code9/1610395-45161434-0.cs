    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;
    
    public class ExportJobs
    {
        public List<Job> JobList { get; } = new List<Job>();
    }
    public class Job
    {
        [XmlAttribute]
        public int Id { get; set; }
        public string Comments { get; set; }
        public DateTime DueDate { get; set; }
        public string FormattedDueDate { get; set; }
        public DateTime TargetDueDate{ get; set; }
        public int ServiceTypeId { get; set; }
        public string ServiceType { get; set; }
        public string TenantName { get; set; }
        public string Uprn { get; set; }
        public string HouseName { get; set; }
    }
    static class P
    {
        
        static void Main()
        {
            var ser = new XmlSerializer(typeof(ExportJobs));
            ExportJobs jobs;
            using (var sr = new StringReader(xml))
            {
                jobs = (ExportJobs) ser.Deserialize(sr);
            }
    
            foreach(var job in jobs.JobList)
            {
                Console.WriteLine($"{job.Id} / {job.Uprn}: {job.DueDate}");
            }  
        }
    
        const string xml = @"<?xml version=""1.0"" encoding=""utf-8""?>
    <ExportJobs xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
      <JobList>
        <Job Id=""555555"">
          <Comments></Comments>
          <DueDate>2017-11-17</DueDate>
          <FormattedDueDate>17-Nov-2017 12:00</FormattedDueDate>
          <TargetDueDate>2017-11-17</TargetDueDate>
          <ServiceTypeId>3</ServiceTypeId>
          <ServiceType>Service</ServiceType>
          <TenantName>Miss Ash</TenantName>
          <Uprn>testUpr</Uprn>
          <HouseName></HouseName>
        </Job>
        <Job Id=""666666"">
          <Comments></Comments>
          <DueDate>2018-03-15</DueDate>
          <FormattedDueDate>15-Mar-2018 12:00</FormattedDueDate>
          <TargetDueDate>2018-03-15</TargetDueDate>
          <ServiceTypeId>3</ServiceTypeId>
          <ServiceType>Service</ServiceType>
          <TenantName>Mr Howard</TenantName>
          <Uprn>testUpr2</Uprn>
        </Job>
      </JobList>
    </ExportJobs>";
    }
