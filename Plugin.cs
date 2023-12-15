using HarmonyLib;
using System.Linq;
using BepInEx;
using KillGiants.Patches;
using UnityEngine;

namespace LC_RemoveGiants
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        private readonly Harmony _harmony = new Harmony(PluginInfo.PLUGIN_GUID);
        private static Plugin _instance;
        
        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }
            // Plugin startup logic
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
            Logger.LogInfo($"[{PluginInfo.PLUGIN_GUID}]: Attempting to patch...");
            
            _harmony.PatchAll(typeof(Plugin));
            _harmony.PatchAll(typeof(ForestGiantRemoval));

            if (_harmony.GetPatchedMethods().Any())
            {
                Logger.LogInfo($"[{PluginInfo.PLUGIN_GUID}]: [Awake] - Patch successful!");
            }
        }
    }
}


namespace KillGiants.Patches
{
    [HarmonyPatch(typeof(ForestGiantAI))]
    internal class ForestGiantRemoval
    {
        [HarmonyPatch(typeof(ForestGiantAI), "Start")]
        [HarmonyPostfix]
        static void RemoveGiant(ForestGiantAI instance)
        {
            instance.KillEnemyOnOwnerClient();
            
            UnityEngine.Object.Destroy(instance.gameObject);
            
            Debug.Log($"[RemoveGiant]: Giant Removed (Hopefully)");
        }
    }
}