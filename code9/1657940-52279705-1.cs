    using Accord.MachineLearning.DecisionTrees;
    using Accord.MachineLearning.DecisionTrees.Learning;
    using Accord.Math.Optimization.Losses;
    using System;
    using System.Data;
    using Accord.Statistics.Filters;
    using System.Linq;
    using Accord.Math;
        
    namespace DecisionTreeExamples
    {
        public class QandADecisionTree{
    
        public static void QandADecisionTreeExample()
        {
            // Step1: Since there was no sample provided in this question, we first construct our data
            DataTable data = new DataTable("QandA");
    
            // Step2: Adding questions. Each question is a column in the data table. 
            PopulateQuestions(data); /*Note that the last column/question is the prediction column. */
    
            // Step3: Adding the history of 6 patients and the corresponding diagnosis (This is also our training data)
            PopulateAnswers(data);
    
            //Step4: Next we need to convert our data table to its numerical representation, which is what ID3 algorithm expects as input.
            Codification codification = new Codification(data);
            DataTable codifiedData = codification.Apply(data);
    
            Console.WriteLine(codifiedData.Columns.Count);
    
            //Note: specify all the columns except the last column, which is the value that the decision tree should predict, 
            int[][] input = codifiedData.ToJagged<int>("Are you above 50 years old?",
                                                       "What is your gender?",
                                                       "Do you have headache?",
                                                       "Has your blood pressure gone above 12 in the last 30 days?",
                                                       "Do you have a running nose?",
                                                       "Do you have a soat throat?",
                                                       "Do you have fever?");
    
            int[] predictions = codifiedData.ToArray<int>("Diagnosed Disease");
    
            // Step4: produce Decision tree.
            ID3Learning decisionTreeLearningAlgorithm = new ID3Learning { };
    
            DecisionTree decisionTree = decisionTreeLearningAlgorithm.Learn(input, predictions);
    
            // Step5: Use the produced decision tree on a test data
            int[] query = codification.Transform(new[,]{ {"Are you above 50 years old?","no" },
                                                       { "What is your gender?","male" },
                                                       { "Do you have headache?" ,"yes"},
                                                       { "Has your blood pressure gone above 12 in the last 30 days?","no" },
                                                       { "Do you have a running nose?","yes" },
                                                       { "Do you have a soat throat?" ,"yes"},
                                                       { "Do you have fever?" ,"yes"} });
    
            int result = decisionTree.Decide(query);
            string diagnosis = codification.Revert("Diagnosed Disease", result);
    
            Console.WriteLine($"Diagnosed disease: {diagnosis}"); // Prints Common Cold
        }
    
        /// <summary>
        /// Populates data table with questions, that in this example each question happens to be a column. 
        /// </summary>
        /// <param name="data">Specifies the data base in this example which is a collection of questions and answers.</param>
        private static void PopulateQuestions(DataTable data)
        {
            data.Columns.Add(new DataColumn("Are you above 50 years old?", typeof(string))); //Q1
            data.Columns.Add(new DataColumn("What is your gender?", typeof(string))); //Q2
            data.Columns.Add(new DataColumn("Do you have headache?", typeof(string))); //Q3
            data.Columns.Add(new DataColumn("Has your blood pressure gone above 12 in the last 30 days?", typeof(string))); //Q4
            data.Columns.Add(new DataColumn("Do you have a running nose?", typeof(string))); //Q5
            data.Columns.Add(new DataColumn("Do you have a soat throat?", typeof(string))); //Q6
            data.Columns.Add(new DataColumn("Do you have fever?", typeof(string))); //Q7
            data.Columns.Add(new DataColumn("Diagnosed Disease", typeof(string))); // Prediction Column
        }
    
        /// <summary>
        /// Populates data table with rows, that in this example each row happens to represent a patient, and each column, except the last one is a question. The value of a column in a row means the reponse patient provided to that question.
        /// </summary>
        /// <param name="data">Specifies the data base in this example which is a collection of questions and answers.</param>
        private static void PopulateAnswers(DataTable data)
        {
            var patient1 = data.NewRow();
            patient1["Are you above 50 years old?"] = "no";
            patient1["What is your gender?"] = "male";
            patient1["Do you have headache?"] = "yes";
            patient1["Has your blood pressure gone above 12 in the last 30 days?"] = "no";
            patient1["Do you have a running nose?"] = "yes";
            patient1["Do you have a soat throat?"] = "yes";
            patient1["Do you have fever?"] = "yes";
            patient1["Diagnosed Disease"] = "Common Cold";
            data.Rows.Add(patient1);
    
            var patient2 = data.NewRow();
            patient2["Are you above 50 years old?"] = "yes";
            patient2["What is your gender?"] = "female";
            patient2["Do you have headache?"] = "yes";
            patient2["Has your blood pressure gone above 12 in the last 30 days?"] = "yes";
            patient2["Do you have a running nose?"] = "no";
            patient2["Do you have a soat throat?"] = "no";
            patient2["Do you have fever?"] = "no";
            patient2["Diagnosed Disease"] = "High Blood Pressure";
            data.Rows.Add(patient2);
    
    
            var patient3 = data.NewRow();
            patient3["Are you above 50 years old?"] = "yes";
            patient3["What is your gender?"] = "male";
            patient3["Do you have headache?"] = "yes";
            patient3["Has your blood pressure gone above 12 in the last 30 days?"] = "yes";
            patient3["Do you have a running nose?"] = "no";
            patient3["Do you have a soat throat?"] = "no";
            patient3["Do you have fever?"] = "no";
            patient3["Diagnosed Disease"] = "High Blood Pressure";
            data.Rows.Add(patient3);
    
            var patient4 = data.NewRow();
            patient4["Are you above 50 years old?"] = "no";
            patient4["What is your gender?"] = "female";
            patient4["Do you have headache?"] = "yes";
            patient4["Has your blood pressure gone above 12 in the last 30 days?"] = "no";
            patient4["Do you have a running nose?"] = "yes";
            patient4["Do you have a soat throat?"] = "yes";
            patient4["Do you have fever?"] = "yes";
            patient4["Diagnosed Disease"] = "Common Cold";
            data.Rows.Add(patient4);
    
            var patient5 = data.NewRow();
            patient5["Are you above 50 years old?"] = "yes";
            patient5["What is your gender?"] = "female";
            patient5["Do you have headache?"] = "yes";
            patient5["Has your blood pressure gone above 12 in the last 30 days?"] = "no";
            patient5["Do you have a running nose?"] = "yes";
            patient5["Do you have a soat throat?"] = "yes";
            patient5["Do you have fever?"] = "yes";
            patient5["Diagnosed Disease"] = "Common Cold";
            data.Rows.Add(patient5);
    
            var patient6 = data.NewRow();
            patient6["Are you above 50 years old?"] = "yes";
            patient6["What is your gender?"] = "female";
            patient6["Do you have headache?"] = "no";
            patient6["Has your blood pressure gone above 12 in the last 30 days?"] = "yes";
            patient6["Do you have a running nose?"] = "no";
            patient6["Do you have a soat throat?"] = "no";
            patient6["Do you have fever?"] = "no";
            patient6["Diagnosed Disease"] = "High Blood Pressure";
            data.Rows.Add(patient6);
        }
    
    }
    }
