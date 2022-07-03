using BepInEx;
using System;
using HarmonyLib;

namespace DiscoShoggoth
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            // Plugin startup logic
            try
            {
                Harmony.CreateAndPatchAll(typeof(AILaserSpecialPatch));
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
            }
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
        }
    }
}
