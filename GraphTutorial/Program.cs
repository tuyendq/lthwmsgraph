using System;
using Microsoft.Extensions.Configuration;

namespace GraphTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(".NET Core Graph Tutorial\n");

            var appConfig = LoadAppSettings();

            if (appConfig == null)
            {
                System.Console.WriteLine("Missing or invalid appsettings.json...existing");
                return;
            }

            var appId = appConfig["appId"];
            var scopesString = appConfig["scopes"];
            var scopes = scopesString.Split(';');

            // Initialize the auth provider
            var authProvider = new DeviceCodeAuthProvider(appId, scopes);

            // Request a token to sign in
            var accessToken = authProvider.GetAccessToken().Result;

            int choice = -1;

            while (choice != 0) {
                System.Console.WriteLine("Please choose one of the following options:");
                System.Console.WriteLine("0. Exit");
                System.Console.WriteLine("1. Display access token");
                System.Console.WriteLine("2. List calendar events");

                try {
                    choice = int.Parse(Console.ReadLine());

                } catch (System.FormatException){
                    // Set to invalid value
                    choice = -1;
                }

                switch(choice) {
                    case 0:
                        // Exit program
                        System.Console.WriteLine("Bye...");
                        break;
                    case 1:
                        // Display access token
                        System.Console.WriteLine($"Access token: {accessToken}\n");
                        break;
                    case 2:
                        // List calendar
                        break;
                    default:
                        System.Console.WriteLine("Invalid choice! Try again.");
                        break;
                }
            }
        }

        static IConfigurationRoot LoadAppSettings()
        {
            var appConfig = new ConfigurationBuilder()
                .AddUserSecrets<Program>()
                .Build();
            
            // Check for required settings
            if (string.IsNullOrEmpty(appConfig["appId"]) || 
                string.IsNullOrEmpty(appConfig["scopes"]))
            {
                return null;
            }

            return appConfig;
        }
    }
}
