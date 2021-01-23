        using Microsoft.LightSwitch;
        using Microsoft.LightSwitch.Details;
        using Microsoft.LightSwitch.Framework;
        using Microsoft.LightSwitch.Threading;
        using System;
        using System.Collections.Generic;
        using System.ComponentModel;
        using System.Diagnostics;
        using System.Linq;
        using System.Reflection;
        namespace LightSwitchApplication.UserCode
        {
            public static class DataUtilities
            {
                public static void DeleteAllSets(this DataWorkspace workspace, params Type[] excludedTypes)
                {
                    List<Type> listExcludedTypes = excludedTypes.ToList();
                    ApplicationData appData = workspace.ApplicationData;
                    IEnumerable<IDataServiceProperty> properties = appData.Details.Properties.All();
                    foreach (IDataServiceProperty prop in properties)
                    {
                        dynamic entitySet = prop.Value;
                        Type entityType = entitySet.GetType().GetGenericArguments()[0];
                        if (!listExcludedTypes.Contains(entityType))
                        {
                            typeof(DataUtilities).GetMethod("DeleteSet", BindingFlags.Static | BindingFlags.Public)
                                                .MakeGenericMethod(entityType)
                                                .Invoke(null, new object[] { entitySet });
                        }
                    }
                    appData.SaveChanges();
                }
                public static void DeleteSet<T>(this EntitySet<T> entities) where T: 
                    IDispatcherObject, IObjectWithDetails, IStructuralObject, INotifyPropertyChanged, IBusinessObject, IEntityObject
                {
                    List<T> entityList = entities.Select(e => e).Execute().ToList();
                    int entityCount = entityList.Count();
                    for (int i = 0; i < entityCount; i++)
                    {
                        T entity = entityList.ElementAt(i);
                        if (entity != null) 
                        { 
                            // Uncomment the line below to see all entities being deleted.
                            // Debug.WriteLine("DELETING " + typeof(T).Name + ": " + entity); 
                            entity.Delete(); 
                        }
                    }
                }
            }
        }
