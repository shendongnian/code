using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Spi;
using System;
using System.Collections.Concurrent;
class JobFactory : IJobFactory
{
    protected readonly IServiceProvider _serviceProvider;
    protected readonly ConcurrentDictionary<IJob, IServiceScope> _scopes = new ConcurrentDictionary<IJob, IServiceScope>();
    public JobFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
    {
        var scope = _serviceProvider.CreateScope();
        IJob job;
        try
        {
            job = scope.ServiceProvider.GetRequiredService(bundle.JobDetail.JobType) as IJob;
        }
        catch
        {
            // Failed to create the job -> ensure scope gets disposed
            scope.Dispose();
            throw;
        }
        // Add scope to dictionary so we can dispose it once the job finishes
        if (!_scopes.TryAdd(job, scope))
        {
            // Failed to track DI scope -> ensure scope gets disposed
            scope.Dispose();
            throw new Exception("Failed to track DI scope");
        }
        return job;
    }
    public void ReturnJob(IJob job)
    {
        if (_scopes.TryRemove(job, out var scope))
        {
            // The Dispose() method ends the scope lifetime.
            // Once Dispose is called, any scoped services that have been resolved from ServiceProvider will be disposed.
            scope.Dispose();
        }
    }
}
The implementation has been tested in a simple setup and worked fine.
Feedback and improvements are more than welcome...
