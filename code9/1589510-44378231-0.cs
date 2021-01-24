    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    
    namespace ConsoleApp1
    {
       public class MyEnumeration
       {
           #region Private Fields
           private readonly string _displayName;
           private readonly int _value;
           private readonly int _interval;
           private readonly Action _action;
           #endregion Private Fields
           #region Protected Constructors
           protected MyEnumeration()
           {
           }
           protected MyEnumeration(int value, string displayName, int interval, Action action)
           {
               _value = value;
               _displayName = displayName;
               _interval = interval;
               _action = action;
           }
           #endregion Protected Constructors
           #region Public Properties
           public string DisplayName
           {
               get { return _displayName; }
           }
           public int Value
           {
               get { return _value; }
           }
           public int Interval
           {
               get { return _interval; }
           }
           public Action Action
           {
               get { return _action; }
           }
           #endregion Public Properties
           #region Public Methods
           public static int AbsoluteDifference(MyEnumeration firstValue, MyEnumeration secondValue)
           {
               var absoluteDifference = Math.Abs(firstValue.Value - secondValue.Value);
               return absoluteDifference;
           }
           public static T FromDisplayName<T>(string displayName) where T : MyEnumeration, new()
           {
               var matchingItem = parse<T, string>(displayName, "display name", item => item.DisplayName == displayName);
               return matchingItem;
           }
           public static T FromValue<T>(int value) where T : MyEnumeration, new()
           {
               var matchingItem = parse<T, int>(value, "value", item => item.Value == value);
               return matchingItem;
           }
           public static IEnumerable<T> GetAll<T>() where T : MyEnumeration, new()
           {
               var type = typeof(T);
               var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);
               foreach (var info in fields)
               {
                   var instance = new T();
                   var locatedValue = info.GetValue(instance) as T;
                   if (locatedValue != null)
                   {
                       yield return locatedValue;
                   }
               }
           }
           public int CompareTo(object other)
           {
               return Value.CompareTo(((MyEnumeration)other).Value);
           }
           public override bool Equals(object obj)
           {
               var otherValue = obj as MyEnumeration;
               if (otherValue == null)
               {
                   return false;
               }
               var typeMatches = GetType().Equals(obj.GetType());
               var valueMatches = _value.Equals(otherValue.Value);
               return typeMatches && valueMatches;
           }
           public override int GetHashCode()
           {
               return _value.GetHashCode();
           }
           public override string ToString()
           {
               return DisplayName;
           }
           #endregion Public Methods
           #region Private Methods
           private static T parse<T, K>(K value, string description, Func<T, bool> predicate) where T : MyEnumeration, new()
           {
               var matchingItem = GetAll<T>().FirstOrDefault(predicate);
               if (matchingItem == null)
               {
                   var message = string.Format("'{0}' is not a valid {1} in {2}", value, description, typeof(T));
                   throw new ApplicationException(message);
               }
               return matchingItem;
           }
           #endregion Private Methods
       }
