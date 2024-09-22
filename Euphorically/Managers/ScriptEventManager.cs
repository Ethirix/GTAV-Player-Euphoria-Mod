using System;

namespace Euphorically.Managers
{
    internal static class ScriptEventManager
    {
        public static EventHandler Tick;
        public static EventHandler PostTick;

        public static void ScriptTick(object sender, EventArgs eventArgs)
        {
            Tick?.Invoke(null, null);
            PostTick?.Invoke(null, null);
        }
    }
}