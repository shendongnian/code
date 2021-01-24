    /// <summary>
        /// Problem statement:
        ///     Given two lists: list1 and list2, find all the sequences of common consecutive items in the two lists.
        /// 
        /// General considerations:
        ///     1. No constraints or limitations are imposed on the two lists, so the lists may contain any number of items, even a very large number of items, therefore the 
        ///        efficiency and performance of the algorithm are paramount.
        ///     2. No constraints or limitations are imposed on the items themselves, so the tow lists may contain any type of items: items of value type or items of reference 
        ///        type.
        ///        For items of reference type, the different references to the common items, stored in the two lists must point to the same memory address (to the same object) 
        ///        and not to two objects who are considered equal by virtue of some properties they have, which happen to have equal values at the moment.
        ///     3. The problem asks for SEQUENCES of items. In this context, a single item may be considered a sequence (an atrophied sequence of a single item).
        ///     4. The problem asks for sequences of COMMON items, so it makes sense to work only with the items contained in both the lists, ignoring all other items (the ones 
        ///        contained only on one of the lists and not contained in the other list) in order to improve the efficiency of the algorithm.
        ///     5. The problem asks for sequences of common CONSECUTIVE items, so the order of the items in of the lists is important. The only items of interest are those common 
        ///        items that form sequences of consecutive items, contained in BOTH the lists and not only in one of them (items that are consecutive in both the lists).
        ///        
        /// The algorithm:
        /// Step 1: Find all the common items of the 2 lists.
        ///         The most efficient way to find all the common items of 2 lists is their intersection:
        ///                  public static IEnumerable<TSource> Intersect<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
        ///         Enumerable.Intersect<TSource> Method: 
        ///         (IEnumerable<TSource>, IEnumerable<TSource>)
        ///         Produces the set intersection of two sequences by using the default equality comparer to compare values.
        ///         The result is an IEnumerable<T> whose distinct elements appear in both IEnumerable<TSource> that are intersected.
        /// Step 2: Find all the sequences of common consecutive items in list1.
        /// Step 3: Find all the sequences of common consecutive items in list2.
        /// Step 4: Find all the sequences of common consecutive items contained in both: list1 and in list2 (the common sequences).
        /// </summary>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        public static List<List<T>> FindAllSequencesOfCommonConsecutiveItemsInTwoLists<T>(List<T> list1, List<T> list2)
        {
            // Step 1: Find all the common items of the 2 lists.
            HashSet<T> list1AsHashSet = new HashSet<T>(list1);
            HashSet<T> list2AsHashSet = new HashSet<T>(list2);
            list1AsHashSet.IntersectWith(list2AsHashSet);
            HashSet<T> allCommonItems = new HashSet<T>(list1AsHashSet);
            // Step 2: Find all the sequences of common consecutive items in list1.
            List<List<T>> sequencesOfCommonConsecutiveItemsInList1 = FindAllSequencesOfConsecutiveItemsInListFormedOnlyWithItemsContainedAlsoInSourceItems(list1, allCommonItems);
            // Step 3: Find all the sequences of common consecutive items in list2.
            List<List<T>> sequencesOfCommonConsecutiveItemsInList2 = FindAllSequencesOfConsecutiveItemsInListFormedOnlyWithItemsContainedAlsoInSourceItems(list2, allCommonItems);
            // Step 4: Find all the sequences of common consecutive items contained in both: list1 and in list2 (the common sequences).
            List<List<T>> commonSequencesOfConsecutiveItems = FindCommonSequencesInTwoListsOfLists(sequencesOfCommonConsecutiveItemsInList1, sequencesOfCommonConsecutiveItemsInList2);
            return commonSequencesOfConsecutiveItems;
        }
        public static List<List<T>> FindAllSequencesOfConsecutiveItemsInListFormedOnlyWithItemsContainedAlsoInSourceItems<T>(List<T> list, HashSet<T> sourceItems)
        {
            if (list == null || list.Count == 0 || sourceItems == null || sourceItems.Count == 0)
            {
                return null;
            }
            List<List<T>> allSequencesOFConsecutiveItemsInList = new List<List<T>>(); /* Holds all the sequences of consecutive items in the list, formed only of items that are also 
                                                                                       * contained in the HashSet sourceItems. 
                                                                                       */
            List<T> sequenceOfConsecutiveItems = null; // Holds a single sequence of consecutive items in the list, formed only of items that are also contained in the HashSet sourceItems.
            HashSet<T> uniqueSequenceStartingItems = new HashSet<T>(); /* This HashSet holds all the items that start a sequence of consecutive items. 
                                                                        * It makes sure that only a single instance of each sequence of items is saved in the List of Lists - no duplicate 
                                                                        * sequences: no two sequences containing the same items in the same order.
                                                                        */
            T currentItem;
            for (int i = 0; i < list.Count; i++)
            {
                sequenceOfConsecutiveItems = new List<T>();
                currentItem = list[i];
                T nextItem;
                if (sourceItems.Contains(currentItem))
                {
                    if (uniqueSequenceStartingItems.Add(currentItem)) /* If it is possible to add currentItem to the HashSet uniqueSequenceStartingItems, it is the first occurrence of this 
                                                                       * specific item.
                                                                       */
                    {
                        sequenceOfConsecutiveItems.Add(currentItem); /* Form a new list containing the new atrophied sequence of consecutive items formed of the single item currentItem, as 
                                                                      * it is this item's first occurrence and so this sequence is the first instance.
                                                                      */
                        allSequencesOFConsecutiveItemsInList.Add(sequenceOfConsecutiveItems); /* Add the new atrophied sequence of consecutive items formed of the single item currentItem 
                                                                                               * to the List of Lists allSequencesOFConsecutiveItemsInList, that will contain all the 
                                                                                               * sequences of consecutive items in the list, formed only of items that are also contained in 
                                                                                               * the HashSet sourceItems. 
                                                                                               */
                        sequenceOfConsecutiveItems = new List<T>(sequenceOfConsecutiveItems); /* Build a new instance of the list sequenceOfConsecutiveItems, already containing the single 
                                                                                               * item currentItem, which starts a new sequence of consecutive items in the list.
                                                                                               * This sequence will be added to the List of Lists allSequencesOFConsecutiveItemsInList only 
                                                                                               * if at least one additional consecutive item in the list will be found, and this item is 
                                                                                               * also contained in the HashSet sourceItems. 
                                                                                               */               
                        bool itemNotContainedInSourceItemsEncountered = false;
                        int j = i;
                        while (j < list.Count - 1 && !itemNotContainedInSourceItemsEncountered) /* Loop through all the adjacent items of currentItem in search of items that are also contained 
                                                                                                 * in the HashSet sourceItems. 
                                                                                                 */
                        {
                            if (j < list.Count - 1)
                            {
                                nextItem = list[j + 1];
                                if (sourceItems.Contains(nextItem)) // An additional consecutive item was found, which is also contained in the HashSet sourceItems. 
                                {
                                    sequenceOfConsecutiveItems.Add(nextItem); // Add this item to the sequence that already contains at least one item.
                                    allSequencesOFConsecutiveItemsInList.Add(sequenceOfConsecutiveItems); /* Add the new sequence of consecutive items to the List of 
                                                                                                           * Lists allSequencesOFConsecutiveItemsInList. 
                                                                                                           */
                                    sequenceOfConsecutiveItems = new List<T>(sequenceOfConsecutiveItems); /* Build a new instance of the list sequenceOfConsecutiveItems, which already contains 
                                                                                                           * some consecutive items in the list where all these items are also contained in the 
                                                                                                           * HashSet sourceItems.
                                                                                                           */        
                                }
                                else /* Here the sequence of consecutive items in the list which are also contained in the HashSet sourceItems ends, as this item is not contained in the HashSet 
                                      * sourceItems.
                                      */
                                {
                                    itemNotContainedInSourceItemsEncountered = true; 
                                    sequenceOfConsecutiveItems = new List<T>(); // Create a new instance of the List sequenceOfConsecutiveItems, for the remaining items in the list.
                                }
                            }
                            j++;
                        }
                    }
                }
            }
            return allSequencesOFConsecutiveItemsInList;
        }
        public static List<List<T>> FindCommonSequencesInTwoListsOfLists<T>(List<List<T>> sequencesOfItemsInList1, List<List<T>> sequencesOfItemsInList2)
        {
            List<List<T>> commonSequencesOfConsecutiveItems = new List<List<T>>();
            for (int i = 0; i < sequencesOfItemsInList1.Count; i++)
            {
                List<T> currentSequenceInList1 = sequencesOfItemsInList1[i];
                for (int j = 0; j < sequencesOfItemsInList2.Count; j++)
                {
                    List<T> currentSequenceInList2 = sequencesOfItemsInList2[j];
                    if (currentSequenceInList1.SequenceEqual(currentSequenceInList2))
                    {
                        commonSequencesOfConsecutiveItems.Add(currentSequenceInList1);
                    }
                }
            }
            return commonSequencesOfConsecutiveItems;
        }
