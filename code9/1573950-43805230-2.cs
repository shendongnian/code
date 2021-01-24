     public class EventsListOptionalParms
            {
                /// Whether to always include a value in the email field for the organizer, creator and attendees, even if no real email is available (i.e. a generated, non-working value will be provided). The use of this option is discouraged and should only be used by clients which cannot handle the absence of an email address value in the mentioned places. Optional. The default is False.
                public bool AlwaysIncludeEmail { get; set; }  
                /// Specifies event ID in the iCalendar format to be included in the response. Optional.
                public string ICalUID { get; set; }  
                /// The maximum number of attendees to include in the response. If there are more than the specified number of attendees, only the participant is returned. Optional.
                public int MaxAttendees { get; set; }  
                /// Maximum number of events returned on one result page. By default the value is 250 events. The page size can never be larger than 2500 events. Optional.
                public int MaxResults { get; set; }  
                /// The order of the events returned in the result. Optional. The default is an unspecified, stable order.
                public string OrderBy { get; set; }  
                /// Token specifying which result page to return. Optional.
                public string PageToken { get; set; }  
                /// Extended properties constraint specified as propertyName=value. Matches only private properties. This parameter might be repeated multiple times to return events that match all given constraints.
                public string PrivateExtendedProperty { get; set; }  
                /// Free text search terms to find events that match these terms in any field, except for extended properties. Optional.
                public string Q { get; set; }  
                /// Extended properties constraint specified as propertyName=value. Matches only shared properties. This parameter might be repeated multiple times to return events that match all given constraints.
                public string SharedExtendedProperty { get; set; }  
                /// Whether to include deleted events (with status equals "cancelled") in the result. Cancelled instances of recurring events (but not the underlying recurring event) will still be included if showDeleted and singleEvents are both False. If showDeleted and singleEvents are both True, only single instances of deleted events (but not the underlying recurring events) are returned. Optional. The default is False.
                public bool ShowDeleted { get; set; }  
                /// Whether to include hidden invitations in the result. Optional. The default is False.
                public bool ShowHiddenInvitations { get; set; }  
                /// Whether to expand recurring events into instances and only return single one-off events and instances of recurring events, but not the underlying recurring events themselves. Optional. The default is False.
                public bool SingleEvents { get; set; }  
                /// Token obtained from the nextSyncToken field returned on the last page of results from the previous list request. It makes the result of this list request contain only entries that have changed since then. All events deleted since the previous list request will always be in the result set and it is not allowed to set showDeleted to False.
    There are several query parameters that cannot be specified together with nextSyncToken to ensure consistency of the client state.
                public string SyncToken { get; set; }  
                /// Upper bound (exclusive) for an event's start time to filter by. Optional. The default is not to filter by start time. Must be an RFC3339 timestamp with mandatory time zone offset, e.g., 2011-06-03T10:00:00-07:00, 2011-06-03T10:00:00Z. Milliseconds may be provided but will be ignored.
                public string TimeMax { get; set; }  
                /// Lower bound (inclusive) for an event's end time to filter by. Optional. The default is not to filter by end time. Must be an RFC3339 timestamp with mandatory time zone offset, e.g., 2011-06-03T10:00:00-07:00, 2011-06-03T10:00:00Z. Milliseconds may be provided but will be ignored.
                public string TimeMin { get; set; }  
                /// Time zone used in the response. Optional. The default is the time zone of the calendar.
                public string TimeZone { get; set; }  
                /// Lower bound for an event's last modification time (as a RFC3339 timestamp) to filter by. When specified, entries deleted since this time will always be included regardless of showDeleted. Optional. The default is not to filter by last modification time.
                public string UpdatedMin { get; set; }  
            
            }
     
            /// <summary>
        /// Returns events on the specified calendar. 
        /// Documentation https://developers.google.com/calendar/v3/reference/events/list
        /// Generation Note: This does not always build corectly.  Google needs to standardise things I need to figuer out which ones are wrong.
        /// </summary>
        /// <param name="service">Authenticated calendar service.</param>  
        /// <param name="calendarId">Calendar identifier. To retrieve calendar IDs call the calendarList.list method. If you want to access the primary calendar of the currently logged in user, use the "primary" keyword.</param>
        /// <param name="optional">Optional paramaters.</param>        /// <returns>EventsResponse</returns>
        public static Events List(calendarService service, string calendarId, EventsListOptionalParms optional = null)
        {
            try
            {
                // Initial validation.
                if (service == null)
                    throw new ArgumentNullException("service");
                if (calendarId == null)
                    throw new ArgumentNullException(calendarId);
                // Building the initial request.
                var request = service.Events.List(calendarId);
                // Applying optional parameters to the request.                
                request = (EventsResource.ListRequest)SampleHelpers.ApplyOptionalParms(request, optional);
                // Requesting data.
                return request.Execute();
            }
            catch (Exception ex)
            {
                throw new Exception("Request Events.List failed.", ex);
            }
        }
