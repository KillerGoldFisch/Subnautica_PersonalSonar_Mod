using GCore.Logging;
using Harmony;

namespace PersonalSonar.Patches {
    [HarmonyPatch(typeof(Knife), "OnToolUseAnim")]
    internal class Knife_OnToolUseAnim_Patch {
        private static bool Prefix() {
            //Log.Debug("Ping");
            SNCameraRoot.main.SonarPing();
            return true;
        }
    }
}