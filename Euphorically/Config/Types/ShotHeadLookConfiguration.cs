using GTA;

namespace Euphorically.Config.Types
{
    internal class ShotHeadLookConfiguration : IConfig
    {
        public void Save(ScriptSettings settings)
        {
            settings.SetValue(nameof(ShotHeadLookConfiguration), nameof(LookAtAttacker), LookAtAttacker);
        }

        public void Load(ScriptSettings settings)
        {
            LookAtAttacker = settings.GetValue(nameof(ShotHeadLookConfiguration), nameof(LookAtAttacker), true);
        }
        
        public bool LookAtAttacker { get; set; }
    }
}