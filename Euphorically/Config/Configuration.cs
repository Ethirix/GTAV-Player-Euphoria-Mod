using Euphorically.Config.Types;
using GTA;

namespace Euphorically.Config
{
    internal class Configuration
    {
        private ScriptSettings _settings;
        private string _fileName;
        
        public ForceConfiguration ForceConfig { get; }
        public DebugConfiguration DebugConfig { get; }

        public Configuration(ScriptSettings settings, string fileName)
        {
            _settings = settings;
            _fileName = fileName;
            
            ForceConfig = new ForceConfiguration();
            DebugConfig = new DebugConfiguration();
        }

        public void Save()
        {
            ForceConfig.Save(_settings);
            DebugConfig.Save(_settings);
            
            _settings.Save();
        }

        public void Load()
        {
            _settings = ScriptSettings.Load(_fileName);
            
            ForceConfig.Load(_settings);
            DebugConfig.Load(_settings);
        }
    }
}