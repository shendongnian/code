        public LearningResultViewModel Learn(EMVDBContext dBContext, string userId, LearningAlgorithm learningAlgorithm)
        {
            var learningDataRaw = dBContext.Mutants
                .Include(mu => mu.MutationOperator)
                .Where(mu => mu.Equivalecy == 0 || mu.Equivalecy == 10);
            string[] featureTitles = new string[] {
            "ChangeType",
            "OperatorName",
            "OperatorBefore",
            "OperatorAfter",
            };
            string[][] learningInputNotCodified = learningDataRaw.Select(ldr => new string[] {
                ldr.ChangeType.ToString(),
                ldr.MutationOperator.Name??"null",
                ldr.MutationOperator.Before??"null",
                ldr.MutationOperator.After??"null",
            }).ToArray();
            int[] learningOutputNotCodified = learningDataRaw.Select(ldr => ldr.Equivalecy == 0 ? 0 : 1).ToArray();
            #region Codification phase
            // Create a new codification codebook to
            // convert strings into discrete symbols
            Codification codebook = new Codification(featureTitles, learningInputNotCodified);
            // Extract input and output pairs to train
            int[][] learningInput = codebook.Transform(learningInputNotCodified);
            switch (learningAlgorithm)
            {
                case LearningAlgorithm.NaiveBayesian:
                    return learningService.NaiveBayes(learningInput, learningOutputNotCodified);
                    break;
                case LearningAlgorithm.SVM:
                    break;
                default:
                    break;
            }
            #endregion
            return null;
        }
