using System;
using Euphorically.Config;
using Euphorically.Debugging;
using Euphorically.Managers;
using Euphorically.Utilities;
using GTA;

namespace Euphorically
{
    internal class Main : Script
    {
        /// <summary>
        /// Determines if the <see cref="T:GTA.Player"/> is currently in an Euphoria-driven Ragdoll
        /// </summary>
        /// <remarks>
        /// Is directly attached to the <see cref="T:GTA.Script"/> as this script focuses exclusively on the <see cref="T:GTA.Player"/>.
        /// <para>May get moved to another <c>class</c> at some point, such as one that handles all Euphoria data.</para>
        /// </remarks>
        public bool IsEuphoriaRagdoll { get; private set; } = false;

        private readonly Random _rnd = new Random();
        
        public Main()
        {
            Configuration.Initialize(Settings, Filename);

            Tick += ScriptEventManager.ScriptTick;
            
            ScriptEventManager.Tick += GameEventManager.Tick;
            ScriptEventManager.PostTick += PostTick;
            
            Logger.LogToFile("Initialization", "Euphorically Started");
        }

        private void PostTick(object sender, EventArgs e)
        {
            Game.Player.Character.ClearLastWeaponDamage();
            Game.Player.Character.ClearLastDamageEntity();
        }


        //TODO: Rewrite
    }
}