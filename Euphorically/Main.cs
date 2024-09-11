using System;
using Euphorically.Config;
using GTA;

namespace Euphorically
{
    public class Main : Script
    {
        /// <summary>
        /// Determines if the <c>Player</c> is currently in an Euphoria-driven Ragdoll
        /// </summary>
        /// <remarks>
        /// Is directly attached to the <c>Script</c> as this script focuses exclusively on the <c>Player</c>.
        /// <para>May get moved to another <c>class</c> at some point, such as one that handles all Euphoria data.</para>
        /// </remarks>
        public bool IsEuphoriaRagdoll { get; private set; } = false;

        private readonly EuphoriaConfig _euphoriaConfig;
        private readonly DebugConfig _debugConfig;
        private readonly Random _rnd = new Random();

        public Main()
        {
            _euphoriaConfig = new EuphoriaConfig(Settings);
            _debugConfig = new DebugConfig(Settings);
        }
        
        //TODO: Rewrite
    }
}