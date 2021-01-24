				int[] arr = ids.ToArray();
				string[] fields = new string[] {
					"System.Id", 
					"System.Title",
					"System.State",
					"System.AssignedTo"
				};
				var workItems = await workItemTrackingHttpClient.GetWorkItemsAsync(arr, fields, workItemQueryResult.AsOf);
				List<WorkItemData> list = new List<WorkItemData>();
				
				foreach (var workItem in workItems)
				{
					var wi = new WorkItemData(workItem.Id.Value);
					
					wi.Title = workItem.Fields["System.Title"].ToString();
					wi.State = workItem.Fields["System.State"].ToString();
					wi.AssignedTo = workItem.Fields.ContainsKey("System.AssignedTo") ? workItem.Fields["System.AssignedTo"].ToString() : "";
					
					list.Add(wi);
					
				}
