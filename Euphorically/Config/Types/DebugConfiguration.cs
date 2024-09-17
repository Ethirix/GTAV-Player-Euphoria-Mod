using GTA;

namespace Euphorically.Config.Types
{
    internal class DebugConfiguration : IConfig
    {
        public void Save(ScriptSettings settings)
        {
            settings.SetValue(nameof(DebugConfiguration), nameof(ShowDebugNotifications), ShowDebugNotifications);
            settings.SetValue(nameof(DebugConfiguration), nameof(PedSearchRadius), PedSearchRadius);
        }

        public void Load(ScriptSettings settings)
        {
            PrintEventsToFile = settings.GetValue(nameof(DebugConfiguration), nameof(PrintEventsToFile), false);
            ShowDebugNotifications = settings.GetValue(nameof(DebugConfiguration), nameof(ShowDebugNotifications), false);
            PedSearchRadius = settings.GetValue(nameof(DebugConfiguration), nameof(PedSearchRadius), 10.0f);
        }
        
        public bool PrintEventsToFile { get; set; }
        public bool ShowDebugNotifications { get; set; }
        public float PedSearchRadius { get; set; }
    }
}