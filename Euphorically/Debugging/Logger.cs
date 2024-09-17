using System;
using System.IO;
using Euphorically.Config;
using Euphorically.Utilities;
using GTA.UI;

namespace Euphorically.Debugging
{
    internal static class Logger
    {
        public static void LogToFile(Configuration config, string category, string message)
        {
            if (config.DebugConfig.PrintEventsToFile)
                File.AppendAllText("Euphorically.log", $"[{DateTime.Now:u}] - [{category.ToUpper()}]: {message}{Environment.NewLine}");
        }

        public static void PushGameNotification(Configuration config, string message)
        {
            if (config.DebugConfig.ShowDebugNotifications)
                Notification.Show(NotificationIcon.DetonateBomb, "Euphorically", "Debugging", message);
        }

        public static void PushGameNotification(Configuration config, GameNotification notification)
        {
            if (config.DebugConfig.ShowDebugNotifications)
                Notification.Show(notification.Icon, notification.Sender, notification.Subject, notification.Message);
        }
    }
}