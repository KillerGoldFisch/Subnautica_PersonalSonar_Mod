using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace PersonalSonar {
    public class Main {
        public static void main() {
            GCore.Logging.Log.LoggingHandler.Add(new GCore.Logging.Logger.DebugLogger());
            //GCore.Logging.Log.LoggingHandler.Add(new GCore.Logging.Logger.FileLogger("glog.txt"));

            //HarmonyInstance.Create("subnautica.personalsonar.mod").PatchAll(Assembly.GetExecutingAssembly());

            SceneManager.sceneLoaded += new UnityAction<Scene, LoadSceneMode>(OnSceneLoaded);
        }

        private static void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
            if (scene.name != "Main")
                return;

            PersonalSonarBehaviour.Load();
        }
    }
}
