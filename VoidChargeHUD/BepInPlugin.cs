using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System.Reflection;
using UnityEngine;

namespace VoidChargeHUD
{
    internal static class MyPluginInfo
    {
        internal const string PLUGIN_GUID = "id107.voidchargehud";
        internal const string PLUGIN_NAME = "VoidChargeHUD";
        internal const string PLUGIN_VERSION = "0.0.2";
    }

    [BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    [BepInProcess("Void Crew.exe")]
    [BepInDependency("VoidManager")]
    public class BepinPlugin : BaseUnityPlugin
    {
        internal static ManualLogSource Log;
        private void Awake()
        {
            Log = Logger;
            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), MyPluginInfo.PLUGIN_GUID);
            Configs.Load(this);
            new GameObject("VoidChargeGUI", typeof(VoidChargeGUI)) { hideFlags = HideFlags.HideAndDontSave };
            Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
        }
    }
}