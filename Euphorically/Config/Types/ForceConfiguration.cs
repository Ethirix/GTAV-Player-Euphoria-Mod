using GTA;

namespace Euphorically.Config.Types
{
    public class ForceConfiguration : IConfig
    {
        public void Save(ScriptSettings settings)
        {
            settings.SetValue(nameof(ForceConfiguration), nameof(UseAdditiveEuphoriaForce), UseAdditiveEuphoriaForce);
            settings.SetValue(nameof(ForceConfiguration), nameof(BaseEuphoriaForce), BaseEuphoriaForce);
            settings.SetValue(nameof(ForceConfiguration), nameof(UseRandomEuphoriaForce), UseRandomEuphoriaForce);
            settings.SetValue(nameof(ForceConfiguration), nameof(MinimumRandomEuphoriaForce), MinimumRandomEuphoriaForce);
            settings.SetValue(nameof(ForceConfiguration), nameof(MaximumRandomEuphoriaForce), MaximumRandomEuphoriaForce);
        }

        public void Load(ScriptSettings settings)
        {
            UseAdditiveEuphoriaForce = settings.GetValue(nameof(ForceConfiguration), nameof(UseAdditiveEuphoriaForce), true);
            BaseEuphoriaForce = settings.GetValue(nameof(ForceConfiguration), nameof(BaseEuphoriaForce), 10.0f);
            UseRandomEuphoriaForce = settings.GetValue(nameof(ForceConfiguration), nameof(UseRandomEuphoriaForce), true);
            MinimumRandomEuphoriaForce = settings.GetValue(nameof(ForceConfiguration), nameof(MinimumRandomEuphoriaForce), 5.0f);
            MaximumRandomEuphoriaForce = settings.GetValue(nameof(ForceConfiguration), nameof(MaximumRandomEuphoriaForce), 15.0f);
        }
        
        public bool UseAdditiveEuphoriaForce { get; set; }
        //TODO: Determine if this is the way to go with Euphoria Additive Forces - such as predefined forces for different weapon types
        public float BaseEuphoriaForce { get; set; }
        public bool UseRandomEuphoriaForce { get; set; }
        public float MinimumRandomEuphoriaForce { get; set; }
        public float MaximumRandomEuphoriaForce { get; set; }
    }
}