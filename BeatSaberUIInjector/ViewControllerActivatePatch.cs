using BeatSaberMarkupLanguage;
using Harmony;
using HMUI;
using System;
using System.IO;
using static HMUI.ViewController;

namespace BeatSaberUIInjector
{
    [HarmonyPatch(typeof(ViewController), "__Activate",
        new Type[] { typeof(ActivationType) })]
    class ViewControllerActivatePatch
    {
        static bool Prefix(ActivationType activationType, ViewController __instance)
        {
            if (__instance.wasActivatedBefore) return true;
            try
            {
                string filePath = $"UserData/UIInjector/{__instance.GetType().Name}.bsml";
                if (File.Exists(filePath))
                {
                    BSMLParser.instance.Parse(File.ReadAllText(filePath), __instance.gameObject, GlobalHost.instance);
                }
            }
            catch
            {
                Logger.log.Error($"Issue injecting UI for {__instance.GetType().Name} perhaps the BSML is invalid?");
            }
            return true;
        }
    }
}
