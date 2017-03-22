
using System.Collections.Generic;
using Microsoft.VisualStudio.Services.Notifications.WebApi;
using Microsoft.VisualStudio.Services.Notifications.WebApi.Clients;
using Microsoft.VisualStudio.Services.WebApi;

namespace VstsSamples.Client.Notification
{ 
    /// <summary>
    /// Samples for getting details about available notification event types.
    /// </summary>
    [ClientSample(NotificationApiConstants.AreaName)]
    public class EventTypesSample : ClientSample
    {
        public EventTypesSample(ClientSampleConfiguration configuration): base(configuration)
        {
        }

        /// <summary>
        /// Returns all event types.
        /// </summary>
        /// <returns></returns>
        [ClientSampleMethod]
        public List<NotificationEventType> GetAllEventTypes()
        {
            VssConnection connection = this.Connection;
            NotificationHttpClient notificationClient = connection.GetClient<NotificationHttpClient>();

            List<NotificationEventType> eventTypes = notificationClient.ListEventTypesAsync().Result;

            return eventTypes;
        }

        /// <summary>
        /// Returns the event types that can be used by a custom subscription.
        /// </summary>
        /// <returns></returns>
        [ClientSampleMethod]
        public List<NotificationEventType> GetEventTypesAvailableForCustomSubscriptions()
        {
            VssConnection connection = this.Connection;
            NotificationHttpClient notificationClient = connection.GetClient<NotificationHttpClient>();

            List<NotificationEventType> eventTypes = notificationClient.ListEventTypesAsync().Result;

            List<NotificationEventType> filteredEventTypes = this.GetAllEventTypes().FindAll(e => {
                return e.CustomSubscriptionsAllowed;
            });

            return filteredEventTypes;
        }
    }

}