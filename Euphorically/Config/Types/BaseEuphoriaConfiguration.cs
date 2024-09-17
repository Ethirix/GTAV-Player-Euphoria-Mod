using Euphorically.Utilities;
using GTA;

namespace Euphorically.Config.Types
{
    internal class BaseEuphoriaConfiguration : IConfig
    {
        public void Save(ScriptSettings settings)
        {
            settings.SetValue(nameof(BaseEuphoriaConfiguration), nameof(BlockEuphoriaWithArmour), BlockEuphoriaWithArmour);
            settings.SetValue(nameof(BaseEuphoriaConfiguration), nameof(BaseEuphoriaCooldown), BaseEuphoriaCooldown);
            settings.SetValue(nameof(BaseEuphoriaConfiguration), nameof(UseRandomEuphoriaCooldown), UseRandomEuphoriaCooldown);
            settings.SetValue(nameof(BaseEuphoriaConfiguration), nameof(MinimumEuphoriaCooldownTime), MinimumEuphoriaCooldownTime);
            settings.SetValue(nameof(BaseEuphoriaConfiguration), nameof(MaximumEuphoriaCooldownTime), MaximumEuphoriaCooldownTime);
            settings.SetValue(nameof(BaseEuphoriaConfiguration), nameof(BaseEuphoriaChance), BaseEuphoriaChance);
            settings.SetValue(nameof(BaseEuphoriaConfiguration), nameof(UseRandomEuphoriaChance), UseRandomEuphoriaChance);
            settings.SetValue(nameof(BaseEuphoriaConfiguration), nameof(MinimumEuphoriaChance), MinimumEuphoriaChance);
            settings.SetValue(nameof(BaseEuphoriaConfiguration), nameof(MaximumEuphoriaChance), MaximumEuphoriaChance);
            settings.SetValue(nameof(BaseEuphoriaConfiguration), nameof(BaseEuphoriaActiveTime), BaseEuphoriaActiveTime);
            settings.SetValue(nameof(BaseEuphoriaConfiguration), nameof(UseRandomEuphoriaActiveTime), UseRandomEuphoriaActiveTime);
            settings.SetValue(nameof(BaseEuphoriaConfiguration), nameof(MinimumEuphoriaActiveTime), MinimumEuphoriaActiveTime);
            settings.SetValue(nameof(BaseEuphoriaConfiguration), nameof(MaximumEuphoriaActiveTime), MaximumEuphoriaActiveTime);
        }

        public void Load(ScriptSettings settings)
        {
            BlockEuphoriaWithArmour = settings.GetValue(nameof(BaseEuphoriaConfiguration), nameof(BlockEuphoriaWithArmour), true);
            
            BaseEuphoriaCooldown = settings.GetValue(nameof(BaseEuphoriaConfiguration), nameof(BaseEuphoriaCooldown), 5f);
            UseRandomEuphoriaCooldown = settings.GetValue(nameof(BaseEuphoriaConfiguration), nameof(UseRandomEuphoriaCooldown), true);
            MinimumEuphoriaCooldownTime = settings.GetValue(nameof(BaseEuphoriaConfiguration), nameof(MinimumEuphoriaCooldownTime), 2f);
            MaximumEuphoriaCooldownTime = settings.GetValue(nameof(BaseEuphoriaConfiguration), nameof(MaximumEuphoriaCooldownTime), 5f);
            
            BaseEuphoriaChance = settings.GetValue(nameof(BaseEuphoriaConfiguration), nameof(BaseEuphoriaChance), 50f);
            UseRandomEuphoriaChance = settings.GetValue(nameof(BaseEuphoriaConfiguration), nameof(UseRandomEuphoriaChance), true);
            MinimumEuphoriaChance = settings.GetValue(nameof(BaseEuphoriaConfiguration), nameof(MinimumEuphoriaChance), 50f);
            MaximumEuphoriaChance = settings.GetValue(nameof(BaseEuphoriaConfiguration), nameof(MaximumEuphoriaChance), 75f);
            
            BaseEuphoriaActiveTime = settings.GetValue(nameof(BaseEuphoriaConfiguration), nameof(BaseEuphoriaActiveTime), 3f);
            UseRandomEuphoriaActiveTime = settings.GetValue(nameof(BaseEuphoriaConfiguration), nameof(UseRandomEuphoriaActiveTime), true);
            MinimumEuphoriaActiveTime = settings.GetValue(nameof(BaseEuphoriaConfiguration), nameof(MinimumEuphoriaActiveTime), 2f);
            MaximumEuphoriaActiveTime = settings.GetValue(nameof(BaseEuphoriaConfiguration), nameof(MaximumEuphoriaActiveTime), 4f);
        }
        
        public bool BlockEuphoriaWithArmour { get; set; }

        public float BaseEuphoriaCooldown { get; set; }
        public bool UseRandomEuphoriaCooldown { get; set; }
        public float MinimumEuphoriaCooldownTime { get; set; }
        public float MaximumEuphoriaCooldownTime { get; set; }
        
        public float BaseEuphoriaChance
        {
            get => _baseEuphoriaChance;
            set => _baseEuphoriaChance = value.Clamp(0f, 100f);
        }
        public bool UseRandomEuphoriaChance { get; set; }

        public float MinimumEuphoriaChance
        {
            get => _minimumEuphoriaChance;
            set => _minimumEuphoriaChance = value.Clamp(0f, 100f);
        }

        public float MaximumEuphoriaChance
        {
            get => _maximumEuphoriaChance;
            set => _maximumEuphoriaChance = value.Clamp(0f, 100f);
        }
        
        public float BaseEuphoriaActiveTime { get; set; }
        public bool UseRandomEuphoriaActiveTime { get; set; }
        public float MinimumEuphoriaActiveTime { get; set; }
        public float MaximumEuphoriaActiveTime { get; set; }

        private float _baseEuphoriaChance;
        private float _minimumEuphoriaChance;
        private float _maximumEuphoriaChance;
    }
}