using CG.Game;
using CG.Ship.Modules;
using Photon.Realtime;

namespace VoidChargeHUD
{
    internal class Helper
    {
        internal static bool IsInPilotsSeat(Player player)
        {
            if (player == null) return false;
            TakeoverChair chair = ClientGame.Current?.PlayerShip?.GetModule<Helm>()?.Chair as TakeoverChair;
            return chair != null && !chair.IsAvailable && player == chair.photonView.Owner;
        }
    }
}
