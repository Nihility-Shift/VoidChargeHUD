using VoidManager.CustomGUI;
using VoidManager.Utilities;
using static UnityEngine.GUILayout;

namespace VoidChargeHUD
{
    internal class GUI : ModSettingsMenu
    {
        private static string textSizeString = Configs.TextSizeConfig.Value.ToString();

        public override string Name() => "Void Charge HUD";

        public override void Draw()
        {
            GUITools.DrawCheckbox("Always display GUI", ref Configs.AlwaysOnConfig);

            Label("");
            BeginHorizontal();
            FlexibleSpace();
            Label("GUI Position");
            FlexibleSpace();
            EndHorizontal();
            Label("x: ");
            if (GUITools.DrawSlider(ref Configs.GUIPosX, 0, 1))
            {
                VoidChargeGUI.Instance.UpdateWindowPos();
            }
            Label("y: ");
            if (GUITools.DrawSlider(ref Configs.GUIPosY, 0, 1))
            {
                VoidChargeGUI.Instance.UpdateWindowPos();
            }
            if (Button("Reset"))
            {
                Configs.GUIPosX.Value = (float)Configs.GUIPosX.DefaultValue;
                Configs.GUIPosY.Value = (float)Configs.GUIPosY.DefaultValue;
                VoidChargeGUI.Instance.UpdateWindowPos();
            }
            Label("");
            if (GUITools.DrawTextField("Text Size", ref textSizeString, Configs.TextSizeConfig.DefaultValue.ToString()))
            {
                if (int.TryParse(textSizeString, out int size))
                {
                    Configs.TextSizeConfig.Value = size;
                }
                else
                {
                    textSizeString = Configs.TextSizeConfig.Value.ToString();
                }
            }
        }
    }
}
