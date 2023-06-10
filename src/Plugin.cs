using BepInEx;
using System;
using HarmonyLib;
using System.IO;
using System.Reflection;
using BepInEx.Logging;

namespace DiscoShoggoth
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        internal static byte[] shoggothImageBytes = new byte[0];
        internal static ManualLogSource Log;
        private void Awake()
        {
            Log = base.Logger;

            Stream imageStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("DiscoShoggoth.res.T_Shoggoth.png");
            MemoryStream memoryStream = new MemoryStream();
            imageStream.CopyTo(memoryStream);
            shoggothImageBytes = memoryStream.ToArray();
            imageStream.Close();
            memoryStream.Close();

            try
            {
                Harmony.CreateAndPatchAll(typeof(AILaserSpecialPatch));
                Harmony.CreateAndPatchAll(typeof(ObjectPoolerPatch));
            }
            catch (Exception e)
            {
                Log.LogError(e.Message);
            }
            Log.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
        }
    }
}
