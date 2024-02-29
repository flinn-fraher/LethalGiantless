using HarmonyLib;
using System.Linq;
using BepInEx;
using BepInEx.Configuration;
using KillGiants;
using UnityEngine;




namespace LC_RemoveGiants
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        private readonly Harmony _harmony = new Harmony(PluginInfo.PLUGIN_GUID);

        public static Plugin _instance;
        public static ConfigEntry<int> cfgMaxGiants;
        public static ConfigEntry<float> cfgGiantSpeed;

        public static int NumGiants;

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }

            // Get configuration values
            cfgMaxGiants = Config.Bind("Main", "MaxGiants", 0, "");
            cfgGiantSpeed = Config.Bind("Main", "GiantMovementSpeed", 1.0f, "");
            
            
            // Plugin startup logic
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} changed!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Logger.LogInfo($"[{PluginInfo.PLUGIN_GUID}]: Attempting to patch...");
            
            Logger.LogInfo($"[Config] Max Giants: {cfgMaxGiants.Value}");
            Logger.LogInfo($"[Config] Giant Move Scalar: {cfgGiantSpeed.Value}");
            
            // _harmony.PatchAll(typeof(Plugin));
            _harmony.PatchAll(typeof(ForestGiantRemoval));


            if (_harmony.GetPatchedMethods().Any())
            {
                Logger.LogInfo($"[{PluginInfo.PLUGIN_GUID}]: [Awake] - Patch successful!");
            }
        }
    }
}


namespace KillGiants
{
    [HarmonyPatch(typeof(ForestGiantAI))]
    internal class ForestGiantRemoval
    {
        [HarmonyPatch(typeof(ForestGiantAI), "Start")]
        [HarmonyPostfix]
        public static void RemoveGiant(ForestGiantAI __instance)
        {
            if (LC_RemoveGiants.Plugin.NumGiants < LC_RemoveGiants.Plugin.cfgMaxGiants.Value)
            {
		        Debug.Log($"[RemoveGiant]: Spawned a single giant");
                EnemyAI AIBehaviour = __instance.gameObject.GetComponent<EnemyAI>();
                if (!AIBehaviour)
                {
                    Debug.Log("[LethalGiantless]: Failed to find associated AI behaviour!!!!!!!!!!!!!!!!!!!!!!!!!!!!! Bad bad bad");
                    return;
                }
         
                AIBehaviour.syncMovementSpeed *= LC_RemoveGiants.Plugin.cfgGiantSpeed.Value;
                LC_RemoveGiants.Plugin.NumGiants++;
                return;
	        }
         
            
            __instance.KillEnemyOnOwnerClient();
            
            UnityEngine.Object.Destroy(__instance.gameObject);
            
            Debug.Log($"[RemoveGiant]: Giant Removed (Hopefully)");

        }
    }
}
