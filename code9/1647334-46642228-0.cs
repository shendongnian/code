    using Microsoft.Azure.Management.Fluent.ServiceBus;
    using Microsoft.Azure.Management.Fluent.ServiceBus.Models;
    using Microsoft.Rest.Azure.Authentication;
    using Microsoft.Rest.Azure.OData;
    
    namespace MonitorDemo
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                var azureTenantId = "tenant Id";
                var azureSecretKey = "secret key";
                var azureAppId = "azure AD application Id";
                var subscriptionId = "subscription Id";
                var resourceGroup = "resource group name";
                var servicePlanName = "service plan name";
                var serviceCreds = ApplicationTokenProvider.LoginSilentAsync(azureTenantId, azureAppId, azureSecretKey).Result;
                MonitorClient monitorClient = new MonitorClient(serviceCreds) { SubscriptionId = subscriptionId };
                var resourceUri = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.Web/serverfarms/{servicePlanName}"; // resource id
                var metricNames = "name.value eq 'CpuPercentage'"; // could be concatenated with " or name.value eq '<another name>'" ... inside parentheses for more than one name.
    
                // The $filter can include time grain, which is optional when metricNames is present. The is forms a conjunction with the list of metric names described above.
                string timeGrain = " and timeGrain eq duration'PT5M'";
    
                // The $filter can also include a time range for the query; also a conjunction with the list of metrics and/or the time grain. Defaulting to 3 hours before the time of execution for these datetimes
                string startDate = " and startTime eq 2017-10-06T08:00:00Z";
                string endDate = " and endTime eq 2017-10-06T09:00:00Z";
    
                var odataFilterMetrics = new ODataQuery<MetricInner>(
                    $"{metricNames}{timeGrain}{startDate}{endDate}");
    
                var metrics = monitorClient.Metrics.ListWithHttpMessagesAsync(resourceUri, odataFilterMetrics).Result;
            }
        }
    }
