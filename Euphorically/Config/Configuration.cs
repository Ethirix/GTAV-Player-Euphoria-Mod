using Euphorically.Config.Types;
using GTA;

namespace Euphorically.Config
{
    internal class Configuration
    {
        public static Configuration Instance { get; private set; }

        public static void Initialize(ScriptSettings settings, string fileName)
        {
            Instance = new Configuration(settings, fileName);
        }
        
        private ScriptSettings _settings;
        private readonly string _fileName;
        
        public BaseEuphoriaConfiguration BaseEuphoriaConfig { get; }
        public ShotConfiguration ShotConfig  { get; }
        public ShotHeadLookConfiguration ShotHeadLookConfig { get; }
        public PointGunConfiguration PointGunConfig { get; }
        public ForceConfiguration ForceConfig { get; }
        public DebugConfiguration DebugConfig { get; }

        private Configuration(ScriptSettings settings, string fileName)
        {
            _settings = settings;
            _fileName = fileName;

            BaseEuphoriaConfig = new BaseEuphoriaConfiguration();
            ShotConfig = new ShotConfiguration();
            ShotHeadLookConfig = new ShotHeadLookConfiguration();
            PointGunConfig = new PointGunConfiguration();
            ForceConfig = new ForceConfiguration();
            DebugConfig = new DebugConfiguration();
        }

        public void Save()
        {
            BaseEuphoriaConfig.Save(_settings);
            ShotConfig.Save(_settings);
            ShotHeadLookConfig.Save(_settings);
            PointGunConfig.Save(_settings);
            ForceConfig.Save(_settings);
            DebugConfig.Save(_settings);
            
            _settings.Save();
        }

        public void Load()
        {
            _settings = ScriptSettings.Load(_fileName);
            
            BaseEuphoriaConfig.Load(_settings);
            ShotConfig.Load(_settings);
            ShotHeadLookConfig.Load(_settings);
            PointGunConfig.Load(_settings);
            ForceConfig.Load(_settings);
            DebugConfig.Load(_settings);
        }
    }
}