     namespace MyCompany.Proofs.WorkFlowCoreProof.BusinessLayer.Workflows.MySpecialObjectInterview.Workflows
        {
            using System;
            using MyCompany.Proofs.WorkFlowCoreProof.BusinessLayer.Workflows.MySpecialObjectInterview.Constants;
            using MyCompany.Proofs.WorkFlowCoreProof.BusinessLayer.Workflows.MySpecialObjectInterview.Glue;
            using MyCompany.Proofs.WorkFlowCoreProof.BusinessLayer.Workflows.WorkflowSteps;
        
            using WorkflowCore.Interface;
            using WorkflowCore.Models;
        
            public class MySpecialObjectInterviewDefaultWorkflow : IWorkflow<MySpecialObjectInterviewPassThroughData>
            {
                public const string WorkFlowId = "MySpecialObjectInterviewWorkflowId";
        
                public const int WorkFlowVersion = 1;
        
                public string Id => WorkFlowId;
        
                public int Version => WorkFlowVersion;
        
                public void Build(IWorkflowBuilder<MySpecialObjectInterviewPassThroughData> builder)
                {
                    builder
                                 .StartWith(context =>
                        {
                            Console.WriteLine("Starting workflow...");
                            return ExecutionResult.Next();
                        })
        
        					/* bunch of other Steps here that were using IMySpecialObjectManager.. here is where my DbContext was getting cross-threaded */
         
        
                        .Then(lastContext =>
                        {
                            Console.WriteLine();
        
                            bool wroteConcreteMsg = false;
                            if (null != lastContext && null != lastContext.Workflow && null != lastContext.Workflow.Data)
                            {
                                MySpecialObjectInterviewPassThroughData castItem = lastContext.Workflow.Data as MySpecialObjectInterviewPassThroughData;
                                if (null != castItem)
                                {
                                    Console.WriteLine("MySpecialObjectInterviewDefaultWorkflow complete :)  {0}   -> {1}", castItem.PropertyOne, castItem.PropertyTwo);
                                    wroteConcreteMsg = true;
                                }
                            }
        
                            if (!wroteConcreteMsg)
                            {
                                Console.WriteLine("MySpecialObjectInterviewDefaultWorkflow complete (.Data did not cast)");
                            }
        
                            return ExecutionResult.Next();
                        }))
        
                        .OnError(WorkflowCore.Models.WorkflowErrorHandling.Retry, TimeSpan.FromSeconds(60));
        
                }
            }
        }
