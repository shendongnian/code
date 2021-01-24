    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("ID", typeof(int));
                dt.Columns.Add("Job Type", typeof(string));
                dt.Columns.Add("Request Date", typeof(DateTime));
                dt.Columns.Add("Job State Type",typeof(string));
                dt.Columns.Add("Payment Call Flag", typeof(Boolean));
                dt.Columns.Add("SSN", typeof(string));
                dt.Columns.Add("Appliacant Type", typeof(string));
                dt.Columns.Add("DOB", typeof(DateTime));
                dt.Columns.Add("First Name", typeof(string));
                dt.Columns.Add("Last Name", typeof(string));
                dt.Columns.Add("City", typeof(string));
                dt.Columns.Add("State", typeof(string));
                dt.Columns.Add("Country", typeof(string));
                dt.Columns.Add("Postal Code", typeof(string));
                dt.Columns.Add("Street Number", typeof(string));
                dt.Columns.Add("Street", typeof(string));
                dt.Columns.Add("Email", typeof(string));
                dt.Columns.Add("Home Phone", typeof(string));
                dt.Columns.Add("Other", typeof(string));
                dt.Columns.Add("Work Phone", typeof(string));
                XDocument doc = XDocument.Load(FILENAME);
                XElement jobApplications = doc.Root;
                int id = (int)jobApplications.Attribute("id");
                foreach (XElement jobApplication in jobApplications.Elements("JobApplication"))
                {
                    string job_type = (string)jobApplication.Attribute("job_type");
                    DateTime request_date = (DateTime)jobApplication.Attribute("request_date");
                    string job_state_type = (string)jobApplication.Descendants("JobApplicationState").FirstOrDefault().Attribute("type");
                    Boolean payment_call_flag = (Boolean)jobApplication.Descendants("JobApplicationState").FirstOrDefault().Attribute("payment_call_flag");
                    foreach (XElement applicant in jobApplication.Descendants("Applicant"))
                    {
                        string social_security_number = (string)applicant.Attribute("social_security_number");
                        string applicant_type = (string)applicant.Attribute("type");
                        DateTime date_of_birth = (DateTime)applicant.Attribute("date_of_birth");
                        string first_name = (string)applicant.Attribute("first_name");
                        string last_name = (string)applicant.Attribute("last_name");
     
                        
                        XElement address = applicant.Descendants("Address").Where(x => (string)x.Attribute("item_code") == "CURRENT").FirstOrDefault();
                        string city = (string)address.Attribute("city");
                        string state = (string)address.Attribute("state_code_id");
                        string country = (string)address.Attribute("country_code");
                        string postal_code = (string)address.Attribute("postal_code");
                        string street_number = (string)address.Attribute("street_number");
                        string street = (string)address.Attribute("street");
                        XElement communications = applicant.Descendants("Communications").FirstOrDefault();
                        string email = communications.Elements().Where(x => (string)x.Attribute("item_code") == "PEMAIL").Select(x => (string)x.Attribute("com")).FirstOrDefault();
                        string home_phone = communications.Elements().Where(x => (string)x.Attribute("item_code") == "HOME").Select(x => (string)x.Attribute("com")).FirstOrDefault();
                        string other = communications.Elements().Where(x => (string)x.Attribute("item_code") == "OTHER").Select(x => (string)x.Attribute("com")).FirstOrDefault();
                        string work_phone = communications.Elements().Where(x => (string)x.Attribute("item_code") == "WORK").Select(x => (string)x.Attribute("com")).FirstOrDefault();
                        dt.Rows.Add(new object[] {
                            id,
                            job_type, request_date, job_state_type, payment_call_flag,
                            social_security_number, applicant_type, date_of_birth, first_name, last_name,
                            city, state, country, postal_code, street_number, street,
                            email, home_phone, other, work_phone
                        });
                    }
                }
            }
        }
    }
