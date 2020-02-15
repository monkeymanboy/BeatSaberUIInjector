using Harmony;
using System;
namespace BeatSaberUIInjector
{
    [HarmonyPatch(typeof(StandardLevelScenesTransitionSetupDataSO), "Finish",
        new Type[] { typeof(LevelCompletionResults) })]
    class LevelFinishPatch
    {
        static bool Prefix(LevelCompletionResults levelCompletionResults)
        {
            GlobalHost.instance.WonLastLevel = levelCompletionResults.levelEndStateType == LevelCompletionResults.LevelEndStateType.Cleared;
            GlobalHost.instance.LostLastLevel = levelCompletionResults.levelEndStateType == LevelCompletionResults.LevelEndStateType.Failed;
            return true;
        }
    }
}
