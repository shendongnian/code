    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Text.RegularExpressions;
    using System.Reflection;
    
    namespace AdvancedList
    {
        public class AdvancedList<T> : BindingList<T>, IBindingListView where T : class
        {
            private bool isSorted;
            private ListSortDirection sortDirection = ListSortDirection.Ascending;
            private PropertyDescriptor sortProperty;
    
            private string filterValue = null;
            private string filterPropertyNameValue;
            private Object filterCompareValue;
    
            private string[] filterPropertyNameValues;
            private Object[] filterCompareValues;
    
            List<T> unfilteredListValue = new List<T>();
    
            // Gets the property that indicates which property we're filtering against.
            public string FilterPropertyName
            {
                get { return filterPropertyNameValue; }
            }
    
            // Gets the property indicating the value we're comparing the property to.
            public Object FilterCompare
            {
                get { return filterCompareValue; }
            }
    
            // Create a blank instance of AdvancedList
            public AdvancedList()
            {
            }
    
            // Populate the list from a source list
            public AdvancedList(List<T> list) : base(list)
            {
            }
    
            // Gets the property that indicates if sorting is supported
            protected override bool SupportsSortingCore
            {
                get { return true; }
            }
    
            // Gets the property that indicates if the list is sorted
            protected override bool IsSortedCore
            {
                get { return isSorted; }
            }
    
            // Gets the proerty indicating the sort direction
            protected override ListSortDirection SortDirectionCore
            {
                get { return sortDirection; }
            }
    
            // Gets the property descriptor used for sorting the list
            protected override PropertyDescriptor SortPropertyCore
            {
                get { return sortProperty; }
            }
    
            // Removes any sorting applied
            protected override void RemoveSortCore()
            {
                sortDirection = ListSortDirection.Ascending;
                sortProperty = null;
                isSorted = false;
            }
    
            // Enables a sorting of the list
            protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
            {
                sortProperty = prop;
                sortDirection = direction;
    
                List<T> list = Items as List<T>;
                if (list == null) return;
    
                list.Sort(Compare);
    
                isSorted = true;
                //fire an event that the list has been changed.
                OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
            }
    
            // Compare the values
            private int Compare(T lhs, T rhs)
            {
                var result = OnComparison(lhs, rhs);
                //invert if descending
                if (sortDirection == ListSortDirection.Descending)
                    result = -result;
                return result;
            }
    
            // Handle different compare instances.
            private int OnComparison(T lhs, T rhs)
            {
                object lhsValue = lhs == null ? null : sortProperty.GetValue(lhs);
                object rhsValue = rhs == null ? null : sortProperty.GetValue(rhs);
                if (lhsValue == null)
                {
                    return (rhsValue == null) ? 0 : -1; //nulls are equal
                }
                if (rhsValue == null)
                {
                    return 1; //first has value, second doesn't
                }
                if (lhsValue is IComparable)
                {
                    return ((IComparable)lhsValue).CompareTo(rhsValue);
                }
                if (lhsValue.Equals(rhsValue))
                {
                    return 0; //both are the same
                }
                //not comparable, compare ToString
                return lhsValue.ToString().CompareTo(rhsValue.ToString());
            }
    
            public void ApplySort(ListSortDescriptionCollection sorts)
            {
                throw new NotImplementedException();
            }
    
            // Return true to indicate this class supports filtering
            public bool SupportsFiltering
            {
                get { return true; }
            }
    
            // Return the unfiltered list.
            public List<T> UnfilteredList
            {
                get { return unfilteredListValue; }
            }
    
            // Get and Set te filter string
            public string Filter
            {
                get
                {
                    return filterValue;
                }
    
                set
                {
                    if (filterValue != value)
                    {
                        RaiseListChangedEvents = false;
    
                        // If filter value is null, reset list.
                        if (value == null)
                        {
                            this.ClearItems();
    
                            foreach (T t in unfilteredListValue)
                                this.Items.Add(t);
    
                            filterValue = value;
                        }
    
                        // If the value is empty string, do nothing.
                        else if (value == "") { }
    
                        // If the value is not null or string, than process normal.
                        // Regex.Matches(value, "[?[\\w]+]? ?[=] ?'?[\\w|/: ]+'?", RegexOptions.Singleline)
                        else if (Regex.Matches(value, "[?[\\w]+]? ?[=] ?'?[\\w]+'?", RegexOptions.Singleline).Count == 0)
                        {
                            // If the filter is not set.
                            unfilteredListValue.Clear();
                            unfilteredListValue.AddRange(this.Items);
                            filterValue = value;
                            GetFilterParts();
                            ApplyFilter();
                        }
                        // Regex.Matches(value, "[?[\\w]+]? ?[=] ?'?[\\w|/: ]+'?", RegexOptions.Singleline)
                        else if (Regex.Matches(value, "[?[\\w]+]? ?[=] ?'?[\\w]+'?", RegexOptions.Singleline).Count > 1)
                        {
                            unfilteredListValue.Clear();
                            unfilteredListValue.AddRange(this.Items);
                            filterValue = value;
                            GetFilterEntries();
                        }
                        else
                            throw new ArgumentException("Filter is not in the format: propName = 'value'.");
    
                        RaiseListChangedEvents = true;
                        OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
                    }
                }
            }
    
            // If multiple filters were specified, separate the filter entries.
            // Incomplete: currently only handles AND. No handling of brackets, OR among others.
            public void GetFilterEntries()
            {
                string[] filterentries = Filter.Split(new string[] { "AND" }, StringSplitOptions.RemoveEmptyEntries);
    
                int index = 0;
    
                foreach (string filter in filterentries)
                {
                    string[] filterParts = filter.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
    
                    filterPropertyNameValues[index] = filterParts[0].Replace("[", "").Replace("]", "").Trim();
    
                    PropertyDescriptor propDesc = TypeDescriptor.GetProperties(typeof(T))[filterPropertyNameValues[0].ToString()];
    
                    if (propDesc != null)
                    {
                        try
                        {
                            TypeConverter converter = TypeDescriptor.GetConverter(propDesc.PropertyType);
                            filterCompareValues[index] = converter.ConvertFromString(filterParts[1].Replace("'", "").Trim());
                        }
                        catch (NotSupportedException)
                        {
                            throw new ArgumentException("Specified filter value " +
                              FilterCompare + " can not be converted from string. Implement a type converter for " + propDesc.PropertyType.ToString());
                        }
                    }
                    else throw new ArgumentException("Specified property '" + filterPropertyNameValues[0] + "' is not found on type " + typeof(T).Name + ".");
                }
            }
    
            // Parse the filter entry to it get the Property Name and Compare Value.
            public void GetFilterParts()
    
            {
                string[] filterParts = Filter.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
    
                filterPropertyNameValue = filterParts[0].Replace("[", "").Replace("]", "").Trim();
    
                PropertyDescriptor propDesc = TypeDescriptor.GetProperties(typeof(T))[filterPropertyNameValue.ToString()];
    
                if (propDesc != null)
                {
                    try
                    {
                        TypeConverter converter = TypeDescriptor.GetConverter(propDesc.PropertyType);
                        filterCompareValue = converter.ConvertFromString(filterParts[1].Replace("'", "").Trim());
                    }
                    catch (NotSupportedException)
                    {
                        throw new ArgumentException("Specified filter value " +
                          FilterCompare + " can not be converted from string. Implement a type converter for " +propDesc.PropertyType.ToString()) ;
                    }
                }
                else throw new ArgumentException("Specified property '" + FilterPropertyName + "' is not found on type " + typeof(T).Name + ".");
            }
    
            // Applies the filter to the list, returning only entries that match the filter.
            // Need a new version of this to handle multiple filters.
            private void ApplyFilter()
            {
                unfilteredListValue.Clear();
                unfilteredListValue.AddRange(this.Items);
    
                List<T> results = new List<T>();
    
                PropertyDescriptor propDesc = TypeDescriptor.GetProperties(typeof(T))[FilterPropertyName];
    
                if (propDesc != null)
                {
                    int tempResults = -1;
    
                    do
                    {
                        tempResults = FindCore(tempResults + 1, propDesc, FilterCompare);
    
                        if (tempResults != -1)
                            results.Add(this[tempResults]);
    
                    } while (tempResults != -1);
                }
    
                this.ClearItems();
    
                if (results != null && results.Count > 0)
                {
                    foreach (T itemFound in results)
                        this.Add(itemFound);
                }
            }
    
            // Remove the filter.
            public void RemoveFilter()
            {
                if (Filter != null) Filter = null;
            }
    
            // Starts FindCore from startIndex 0 if no index was provided.
            protected override int FindCore(PropertyDescriptor prop, object key)
            {
                return FindCore(0, prop, key);
            }
    
            // Finds a List entry wher the Property value matches the compare value (key)
            protected int FindCore(int startIndex, PropertyDescriptor prop, object key)
            {
                // Get the property info for the specified property.
                PropertyInfo propInfo = typeof(T).GetProperty(prop.Name);
    
                T item;
    
                if (key != null)
                {
                    // Loop through the items to see if the key value matches the property value.
                    for (int i = startIndex; i < Count; ++i)
                    {
                        item = (T)Items[i];
                        if (propInfo.GetValue(item, null).Equals(key))
                            return i;
                    }
                }
                return -1;
            }
    
            // Required to implement IBindingListView, but not implemented here
            public ListSortDescriptionCollection SortDescriptions => throw new NotImplementedException();
    
            // Required to implement IBindingListView, but not implemented
            //public bool SupportsAdvancedSorting => throw new NotImplementedException();
            public bool SupportsAdvancedSorting
            {
                get { return false; }
            }
    
            // End of Class
        }
    
        // End of Namespace
    }
