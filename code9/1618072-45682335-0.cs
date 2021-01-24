        /// <summary>
        /// Implementation of `git show-branch --indepenent`
        /// 
        /// "Among the <reference>s given, display only the ones that cannot be reached from any other <reference>"
        /// </summary>
        /// <param name="commitsToCheck"></param>
        /// <returns></returns>
        private List<Commit> GetIndependent(IRepository repo, IEnumerable<Commit> commitsToCheck)
        {
            var commitList = commitsToCheck.ToList();
            for (var i = commitList.Count - 1; i > 0; --i)
            {
                var first = commitList[i];
                for (var j = commitList.Count - 1; j >= 0; --j)
                {
                    if (i == j) continue;
                    var second = commitList[j];
                    var mergeBase = repo.ObjectDatabase.FindMergeBase(first, second);
                    if (first.Equals(mergeBase))
                    {
                        // First commit (i) is reachable from second (j), so drop i
                        commitList.RemoveAt(i);
                        // No reason to check anything else against this commit
                        j = -1;
                    } else if (second.Equals(mergeBase))
                    {
                        // Second (j) is reachable from first, so drop j
                        commitList.RemoveAt(j);
                        // If this was at a lower index than i, dec i since we shifted one down
                        if (j < i)
                        {
                            --i;
                        }
                    }
                }
            }
            return commitList;
        }
