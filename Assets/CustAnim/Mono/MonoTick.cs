using System.Collections.Generic;
using UnityEngine;

namespace CustAnim.Mono
{
    public class MonoTick : MonoBehaviour
    {
        [SerializeField] private bool update = true;
        [SerializeField] private bool fixedUpdate = true;
        [SerializeField] private bool lateUpdate = true;
        
        private static readonly List<UpdateTick> UpdateTicks = new List<UpdateTick>();
        private static readonly List<FixedUpdateTick> FixedUpdateTicks = new List<FixedUpdateTick>();
        private static readonly List<LateUpdateTick> LateUpdateTicks = new List<LateUpdateTick>();

        public static void Add(UpdateTick updateTick)
        {
            UpdateTicks.Add(updateTick);
        }
        public static void Add(FixedUpdateTick fixedUpdateTick)
        {
            FixedUpdateTicks.Add(fixedUpdateTick);
        }
        public static void Add(LateUpdateTick lateUpdateTick)
        {
            LateUpdateTicks.Add(lateUpdateTick);
        }
        
        public static void Remove(UpdateTick updateTick)
        {
            UpdateTicks.Remove(updateTick);
        }
        public static void Remove(FixedUpdateTick fixedUpdateTick)
        {
            FixedUpdateTicks.Remove(fixedUpdateTick);
        }
        public static void Remove(LateUpdateTick lateUpdateTick)
        {
            LateUpdateTicks.Remove(lateUpdateTick);
        }

        private void Update()
        {
            if (!update) return;
            
            foreach (var t in UpdateTicks)
                t.Tick();
        }
        private void FixedUpdate()
        {
            if (!fixedUpdate) return;
            
            foreach (var t in FixedUpdateTicks)
                t.Tick();
        }
        private void LateUpdate()
        {
            if (!lateUpdate) return;
            
            foreach (var t in LateUpdateTicks)
                t.Tick();
        }
    }
}