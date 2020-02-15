using Harmony;
using IPA;
using System;
using System.Reflection;
using UnityEngine.SceneManagement;
using IPALogger = IPA.Logging.Logger;

namespace BeatSaberUIInjector
{
    public class Plugin : IBeatSaberPlugin
    {
        public void Init(IPALogger logger)
        {
            Logger.log = logger;
        }
        
        public void OnApplicationStart()
        {
            try
            {
                HarmonyInstance harmony = HarmonyInstance.Create("com.monkeymanboy.BeatSaber.BeatSaberUIInjector");
                harmony.PatchAll(Assembly.GetExecutingAssembly());
            }
            catch (Exception e)
            {
                Logger.log.Critical(e);
            }
        }

        public void OnApplicationQuit() { }
        public void OnFixedUpdate() { }
        public void OnUpdate() { }
        public void OnActiveSceneChanged(Scene prevScene, Scene nextScene) { }
        public void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode) { }
        public void OnSceneUnloaded(Scene scene) { }
    }
}
