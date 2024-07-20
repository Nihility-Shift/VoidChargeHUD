using VoidManager.MPModChecks;

namespace VoidChargeHUD
{
    public class VoidManagerPlugin : VoidManager.VoidPlugin
    {
        public override MultiplayerType MPType => MultiplayerType.Client;

        public override string Author => "18107";

        public override string Description => "Displays the void charge state while in the pilot's seat";
    }
}
