using BepInEx.Configuration;

namespace VoidChargeHUD
{
    internal class Configs
    {
        internal static ConfigEntry<bool> AlwaysOnConfig;
        internal static ConfigEntry<float> GUIPosX;
        internal static ConfigEntry<float> GUIPosY;
        internal static ConfigEntry<int> TextSizeConfig;

        internal static void Load(BepinPlugin plugin)
        {
            AlwaysOnConfig = plugin.Config.Bind("VoidChargeHUD", "AlwaysOn", false);
            GUIPosX = plugin.Config.Bind("VoidChargeHUD", "GUIPosX", 0.93f);
            GUIPosY = plugin.Config.Bind("VoidChargeHUD", "GUIPosY", 0.806f);
            TextSizeConfig = plugin.Config.Bind("VoidChargeHUD", "TextSize", 15);
        }
    }
}
