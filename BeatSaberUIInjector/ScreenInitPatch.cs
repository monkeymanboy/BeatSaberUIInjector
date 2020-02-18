using BeatSaberMarkupLanguage;
using Harmony;
using System;
using System.IO;
using Image = UnityEngine.UI.Image;
using Screen = HMUI.Screen;

namespace BeatSaberUIInjector
{
    [HarmonyPatch(typeof(Screen), "Init",
        new Type[] { })]
    class ScreenInitPatch
    {
        static bool Prefix(Screen __instance)
        {
            Image image = __instance.GetComponent<Image>();
            if (image == null) return true;
            if (File.Exists($"UserData/UIInjector/{__instance.name}.background"))
            {
                image.SetImage(File.ReadAllText($"UserData/UIInjector/{__instance.name}.background"));
            } else if(File.Exists("UserData/UIInjector/All.background"))
            {
                image.SetImage(File.ReadAllText("UserData/UIInjector/All.background"));
            }
            return true;
        }
    }
}
