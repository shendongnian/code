            private static void UnsubscribeOne(object target)
        {
            Delegate[] subscribers;
            Type targetType;
            string EventName = "EVENT_DATAGRIDVIEWCELLCLICK";
            targetType = target.GetType();
            do
            {
                FieldInfo[] fields = targetType.GetFields(BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic);
                foreach (FieldInfo field in fields)
                {
                    if (field.Name == EventName)
                    {
                        EventHandlerList eventHandlers = ((EventHandlerList)(target.GetType().GetProperty("Events", (BindingFlags.FlattenHierarchy | (BindingFlags.NonPublic | BindingFlags.Instance))).GetValue(target, null)));
                        Delegate d = eventHandlers[field.GetValue(target)];
                        if ((!(d == null)))
                        {
                            subscribers = d.GetInvocationList();
                            foreach (Delegate d1 in subscribers)
                            {
                                targetType.GetEvent("CellClick").RemoveEventHandler(target, d1);
                            }
                            return;
                        }
                    }
                }
                targetType = targetType.BaseType;
            } while (targetType != null);
        }
