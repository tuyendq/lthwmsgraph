using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphTutorial
{
    public class GraphHelper
    {
        private static GraphServiceClient graphClient;
        public static void Initialize(IAuthenticationProvider authProvider)
        {
            graphClient = new GraphServiceClient(authProvider);
        }

        public static async Task<User> GetMeAsync()
        {
            try
            {
                // Get /me
                return await graphClient.Me.Request().GetAsync();
            }
            catch (ServiceException ex)
            {
                System.Console.WriteLine($"Error getting signed-in user: {ex.Message}");
                return null;
            }
        }

        public static async Task<IEnumerable<Event>> GetEventsAsync()
        {
            try
            {
                // Get /me/events
                var resultPage = await graphClient.Me.Events.Request()
                    // Only return the fields used by the application
                    .Select("subject,organizer,start,end")
                    // Sort results by when they were created, newest first
                    .OrderBy("createdDateTime DESC")
                    .GetAsync();
                
                return resultPage.CurrentPage;
            }
            catch (ServiceException ex)
            {
                System.Console.WriteLine($"Error getting events: {ex.Message}");
                return null;
            }
        }

    }
}