using GTA;

namespace Euphorically.Config.Types
{
    internal class PointGunConfiguration : IConfig
    {
        public void Save(ScriptSettings settings)
        {
            settings.SetValue(nameof(PointGunConfiguration), nameof(AimAtAttacker), AimAtAttacker);
            settings.SetValue(nameof(PointGunConfiguration), nameof(TurnToAttacker), TurnToAttacker);
        }

        public void Load(ScriptSettings settings)
        {
            AimAtAttacker = settings.GetValue(nameof(PointGunConfiguration), nameof(AimAtAttacker), true);
            TurnToAttacker = settings.GetValue(nameof(PointGunConfiguration), nameof(TurnToAttacker), true);
        }
        
        public bool AimAtAttacker { get; set; }
        public bool TurnToAttacker { get; set; }
    }
}