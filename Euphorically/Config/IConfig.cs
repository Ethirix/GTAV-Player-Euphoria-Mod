using GTA;

namespace Euphorically.Config
{
    internal interface IConfig
    {
        void Save(ScriptSettings settings);
        void Load(ScriptSettings settings);
    }
}