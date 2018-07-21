using GCore.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace PersonalSonar {
    public class PersonalSonarBehaviour : MonoBehaviour {
        public static PersonalSonarBehaviour Instance { get; private set; }

        public static readonly KeyCode PingHotkey = KeyCode.F;
        public static readonly KeyCode ToggleHotkey = KeyCode.P;

        public static readonly TimeSpan PingCooldown = TimeSpan.FromSeconds(4);

        public static bool IsActive { get; set; } = true;

        public static bool Toggled { get; set; } = false;

        private DateTime _lastPing = DateTime.Now;


        public static void Load() {
            if (Instance != null)
                return;
            
            Instance = FindObjectOfType(typeof(PersonalSonarBehaviour)) as PersonalSonarBehaviour;
            if (Instance != null)
                return;

            GameObject psb = new GameObject().AddComponent<PersonalSonarBehaviour>().gameObject;
            psb.name = "PersonalSonarBehaviour";
            Instance = psb.GetComponent<PersonalSonarBehaviour>();

            Log.Success("PersonalSonarBehaviour loaded");
        }

        public void Update() {
            if (Player.main == null || !IsActive)
                return;

            if (Input.GetKeyDown(ToggleHotkey))
                Toggled = !Toggled;

            if (!Input.GetKeyDown(PingHotkey) && !Toggled)
                return;

            if (DateTime.Now - _lastPing < PingCooldown)
                return;

            _lastPing = DateTime.Now;
            SNCameraRoot.main.SonarPing();
        }
    }
}
