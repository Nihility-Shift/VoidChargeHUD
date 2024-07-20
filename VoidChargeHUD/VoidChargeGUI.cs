using CG.Client;
using CG.Game;
using CG.Ship.Modules;
using Photon.Pun;
using UnityEngine;

namespace VoidChargeHUD
{
    internal class VoidChargeGUI : MonoBehaviour
    {
        private bool mainUiEnabled = true;
        private bool guiActive = false;
        internal Rect WindowPos;
        internal const float width = 80;
        internal const float height = 24;
        VoidDriveModule voidDrive;

        internal static VoidChargeGUI Instance { get; private set; }

        private VoidChargeGUI()
        {
            Instance = this;
            VoidManager.Utilities.Tools.DelayDo(() => ViewEventBus.Instance.OnUIToggle.Subscribe(enable => mainUiEnabled = enable), 12000);
        }

        internal void UpdateWindowPos()
        {
            WindowPos = new Rect(Screen.width * Configs.GUIPosX.Value, Screen.height * Configs.GUIPosY.Value, width, height);
        }

        private void Update()
        {
            bool shouldBeActive = mainUiEnabled && (Configs.AlwaysOnConfig.Value || Helper.IsInPilotsSeat(PhotonNetwork.LocalPlayer)) && ClientGame.Current?.PlayerShip?.InteriorAtmosphere != null;
            if (shouldBeActive != guiActive)
            {
                guiActive = !guiActive;
                WindowPos = new(Screen.width * Configs.GUIPosX.Value, Screen.height * Configs.GUIPosY.Value, width, height);
                voidDrive = ClientGame.Current.PlayerShip.GameObject.GetComponentInChildren<VoidDriveModule>();
            }
        }

        private void OnGUI()
        {
            if (guiActive)
            {
                UnityEngine.GUI.Window(718107, WindowPos, null,
                    $"<color=#ffffff><size=15><b>{voidDrive.JumpCharge*100:0}%</b></size></color>", GUIStyle.none);
            }
        }
    }
}
