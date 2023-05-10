using UnityEngine;

namespace CustAnim.Mono
{
    public abstract class LateUpdateTick : MonoBehaviour
    {
        private void OnEnable()
        {
            MonoTick.Add(this);
        }
        private void OnDisable()
        {
            MonoTick.Remove(this);
        }

        public virtual void Tick()
        {
            
        }
    }
}
