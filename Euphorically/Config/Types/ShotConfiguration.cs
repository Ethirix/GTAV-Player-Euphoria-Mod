using Euphorically.Utilities;
using GTA;

namespace Euphorically.Config.Types
{
    internal class ShotConfiguration : IConfig
    {
        public void Save(ScriptSettings settings)
        {
            settings.SetValue(nameof(ShotConfiguration), nameof(UseInjuredArm), UseInjuredArm);
            settings.SetValue(nameof(ShotConfiguration), nameof(UseInjuredLeg), UseInjuredLeg);
            settings.SetValue(nameof(ShotConfiguration), nameof(UseReachForWound), UseReachForWound);
            settings.SetValue(nameof(ShotConfiguration), nameof(UseLowerLegReach), UseLowerLegReach);
            settings.SetValue(nameof(ShotConfiguration), nameof(DelayBeforeReachForWound), DelayBeforeReachForWound);
            settings.SetValue(nameof(ShotConfiguration), nameof(BodyStiffness), BodyStiffness);
            settings.SetValue(nameof(ShotConfiguration), nameof(ArmStiffness), ArmStiffness);
            settings.SetValue(nameof(ShotConfiguration), nameof(NeckStiffness), NeckStiffness);
            settings.SetValue(nameof(ShotConfiguration), nameof(SpineLeanMagnitude), SpineLeanMagnitude);
        }

        public void Load(ScriptSettings settings)
        {
            UseInjuredArm = settings.GetValue(nameof(ShotConfiguration), nameof(UseInjuredArm), true);
            UseInjuredLeg = settings.GetValue(nameof(ShotConfiguration), nameof(UseInjuredLeg), true);
            UseReachForWound = settings.GetValue(nameof(ShotConfiguration), nameof(UseReachForWound), true);
            UseLowerLegReach = settings.GetValue(nameof(ShotConfiguration), nameof(UseLowerLegReach), true);
            DelayBeforeReachForWound = settings.GetValue(nameof(ShotConfiguration), nameof(DelayBeforeReachForWound), 0f);
            BodyStiffness = settings.GetValue(nameof(ShotConfiguration), nameof(BodyStiffness), 11f);
            ArmStiffness = settings.GetValue(nameof(ShotConfiguration), nameof(ArmStiffness), 10f);
            NeckStiffness = settings.GetValue(nameof(ShotConfiguration), nameof(NeckStiffness), 14f);
            SpineLeanMagnitude = settings.GetValue(nameof(ShotConfiguration), nameof(SpineLeanMagnitude), 1f);
        }
        
        public bool UseInjuredArm { get; set; }
        public bool UseInjuredLeg { get; set; }
        public bool UseReachForWound { get; set; }
        public bool UseLowerLegReach { get; set; }

        /// <summary>
        /// Clamped between 0.0 and 10.0.
        /// </summary>
        public float DelayBeforeReachForWound
        {
            get => _delayBeforeReachForWound;
            set => _delayBeforeReachForWound = value.Clamp(0f, 10f);
        }
        
        /// <summary>
        /// Clamped between 6.0 and 16.0.
        /// </summary>
        public float BodyStiffness
        {
            get => _bodyStiffness;
            set => _bodyStiffness = value.Clamp(6f, 16f);
        }

        /// <summary>
        /// Clamped between 6.0 and 16.0.
        /// </summary>
        public float ArmStiffness
        {
            get => _armStiffness;
            set => _armStiffness = value.Clamp(6f, 16f);
        }

        /// <summary>
        /// Clamped between 6.0 and 16.0.
        /// </summary>
        public float NeckStiffness
        {
            get => _neckStiffness;
            set => _neckStiffness = value.Clamp(6f, 16f);
        }

        /// <summary>
        /// Clamped between 0.0 and 10.0.
        /// </summary>
        public float SpineLeanMagnitude
        {
            get => _spineLeanMagnitude;
            set => _spineLeanMagnitude = value.Clamp(0f, 10f);
        }
        
        private float _delayBeforeReachForWound;
        private float _bodyStiffness;
        private float _armStiffness;
        private float _neckStiffness;
        private float _spineLeanMagnitude;
    }
}