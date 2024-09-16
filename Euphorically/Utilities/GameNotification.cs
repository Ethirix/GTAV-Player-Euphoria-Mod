using GTA.UI;

namespace Euphorically.Utilities
{
    public struct GameNotification
    {
        public NotificationIcon Icon { get; set; }
        public string Sender { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}