    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Logs> logs = new List<Logs>();
                List<Step> steps = new List<Step>();
                List<Set> sets = new List<Set>();
                List<Batch> batches = new List<Batch>();
                List<Event> events = new List<Event>(); 
           
                int BatchId = 123;
                var results = (from log in logs
                               join step in steps on log.Steps_StepId equals step.StepId
                               join set in sets on log.Sets_SetId equals set.SetId
                               join batch in batches on log.Batch_BatchId equals batch.BatchId
                               join _event in events on log.Events_EventId equals _event.EventId
                               select new { log = log, step = step, set = set, batch = batch, _event = _event })
                               .Where(x => x.batch.BatchId == BatchId)
                               .Select(x => new {
                                   description = x.batch.Description,
                                   eventCode = x._event.Code,
                                   date = x.log.Date,
                                   stepId = x.step.StepId,
                                   stepDescription = x.step.Description,
                                   setType = x.set.SetId
                               }).ToList();
            }
        }
        public class Logs
        {
            public int Batch_BatchId { get; set; }
            public int Steps_StepId { get; set; }
            public int Sets_SetId { get; set; }
            public DateTime Date { get; set; }
            public int Events_EventId { get; set; }
        }
        public class JoinedModel
        {
            public Batch batch { get; set; }
            public List<Step> Steps { get; set; }
        }
        public class Step
        {
            public int StepId { get; set; }
            public string Description { get; set; }
            public List<Set> Sets { get; set; }
        }
        public class Set
        {
            public int SetId { get; set; }
            public string Type { get; set; }
            public string EventCode { get; set; }
        }
        public class Batch
        {
            public int BatchId { get; set; }
            public string Description { get; set; }
        }
        public class Event
        {
            public int EventId { get; set; }
            public int Code { get; set; }
        }
    }
