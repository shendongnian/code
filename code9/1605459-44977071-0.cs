	using System;
	using System.Collections.Generic;
	using Newtonsoft.Json;
					
	public class Program
	{
		public static void Main()
		{
			string json = @"{
	""CreatedBy"": null,
	""CanBeRemoved"": false,
	""ConfigurationItems"": [ """" ],
	""ApprovalReasons"": [
  	{
      ""AssociatedCI"": """",
      ""AssociatedRuleName"": ""BRS: "",
      ""AssociatedRuleApprovalType"": null,
      ""AssociatedRulePartyType"": ""Group"",
      ""AssociatedRulePartyName"": ""Digital "",
      ""AssociatedAdditionalComment"": ""Added to all ""
    }],
	""PossibleApprovers"": [
    {
      ""Approver"": {
        ""Display"": ""Jag"",
        ""StandardId"": ""I6"",
        ""RoleName"": null,
        ""FullName"": null,
        ""LineOfBusiness"": null,
        ""ErrorMessage"": null
      },
      ""IsEscalation"": false,
      ""IsDelegate"": false
    },
    {
      ""Approver"": {
        ""Display"": ""Will"",
        ""StandardId"": ""U55"",
        ""RoleName"": null,
        ""FullName"": null,
        ""LineOfBusiness"": null,
        ""ErrorMessage"": null
      },
      ""IsEscalation"": false,
      ""IsDelegate"": false
    },
    {
      ""Approver"": {
        ""Display"": ""Su"",
        ""StandardId"": ""U2"",
        ""RoleName"": null,
        ""FullName"": null,
        ""LineOfBusiness"": null,
        ""ErrorMessage"": null
      },
      ""IsEscalation"": false,
      ""IsDelegate"": false
    }],
  	""OriginalApprovals"": [],
  	""AggregatedApproval"": null,
  	""IsAggregated"": false,
  	""AggregationId"": 0,
  	""UpdatedBy"": null,
  	""UpdatedDt"": null,
  	""IsGroupActive"": false
	}";
		
			var m = JsonConvert.DeserializeObject<RootObject>(json);
			foreach(var possibleApprovers in m.PossibleApprovers)
			{
				Console.WriteLine(possibleApprovers.Approver.StandardId);
			}
		}
		public class ApprovalReason
		{
    		public string AssociatedCI { get; set; }
    		public string AssociatedRuleName { get; set; }
    		public object AssociatedRuleApprovalType { get; set; }
    		public string AssociatedRulePartyType { get; set; }
    		public string AssociatedRulePartyName { get; set; }
    		public string AssociatedAdditionalComment { get; set; }
		}
		public class Approver
		{
    		public string Display { get; set; }
    		public string StandardId { get; set; }
    		public object RoleName { get; set; }
    		public object FullName { get; set; }
    		public object LineOfBusiness { get; set; }
    		public object ErrorMessage { get; set; }
		}
		public class PossibleApprover
		{
    		public Approver Approver { get; set; }
    		public bool IsEscalation { get; set; }
    		public bool IsDelegate { get; set; }
		}
		public class RootObject
		{
    		public object CreatedBy { get; set; }
    		public bool CanBeRemoved { get; set; }
    		public List<string> ConfigurationItems { get; set; }
    		public List<ApprovalReason> ApprovalReasons { get; set; }
    		public List<PossibleApprover> PossibleApprovers { get; set; }
    		public List<object> OriginalApprovals { get; set; }
    		public object AggregatedApproval { get; set; }
    		public bool IsAggregated { get; set; }
    		public int AggregationId { get; set; }
    		public object UpdatedBy { get; set; }
    		public object UpdatedDt { get; set; }
    		public bool IsGroupActive { get; set; }
		}
	}
