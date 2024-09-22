using System;
using System.Linq;
using Euphorically.Config;
using Euphorically.Utilities;
using GTA;

namespace Euphorically.Managers
{
    internal static class GameEventManager
    {
        /// <summary>
        /// Fired upon the <see cref="T:GTA.Player"/> receiving ranged damage.
        /// Passes the <see cref="T:GTA.Ped"/> responsible, if found.
        /// </summary>
        public static EventHandler<Ped> PlayerRangedDamageReceived;
        /// <summary>
        /// Fired upon the <see cref="T:GTA.Player"/> receiving melee damage.
        /// Passes the <see cref="T:GTA.Ped"/> responsible, if found.
        /// </summary>
        public static EventHandler<Ped> PlayerMeleeDamageReceived;
        
        public static void Tick(object sender, EventArgs eventArgs)
        {
            HandlePlayerDamageEvents();
        }

        private static void HandlePlayerDamageEvents()
        {
            //TODO: Add config to differentiate between melee and ranged damage.
            Ped player = Game.Player.Character;
            
            Ped attacker = World.GetNearbyPeds(player, Configuration.Instance.DebugConfig.PedSearchRadius,
                Array.Empty<Model>()).FirstOrDefault(p => player.HasBeenDamagedBy(p));
            
            if (attacker is null)
                return;

            DamageType damageType = DamageType.None;
            if (player.HasBeenDamagedByAnyWeapon() && !player.HasBeenDamagedByAnyMeleeWeapon())
                damageType = DamageType.Ranged;
            else if (player.HasBeenDamagedByAnyMeleeWeapon())
                damageType = DamageType.Melee;

            switch (damageType)
            {
                case DamageType.None:
                    return;
                case DamageType.Melee:
                    //TODO: Melee Config
                    break;
                case DamageType.Ranged:
                    //TODO: Ranged Config
                    break;
            }
        }
    }
}