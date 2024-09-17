using System;
using Euphorically.Config;
using GTA;

namespace Euphorically
{
    internal class Main : Script
    {
        /// <summary>
        /// Determines if the <c>Player</c> is currently in an Euphoria-driven Ragdoll
        /// </summary>
        /// <remarks>
        /// Is directly attached to the <c>Script</c> as this script focuses exclusively on the <c>Player</c>.
        /// <para>May get moved to another <c>class</c> at some point, such as one that handles all Euphoria data.</para>
        /// </remarks>
        public bool IsEuphoriaRagdoll { get; private set; } = false;

        private readonly Configuration _config;
        private readonly Random _rnd = new Random();

        public Main()
        {
            _config = new Configuration(Settings, Filename);
        }
        
        //TODO: Rewrite
    }
}