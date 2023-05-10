using CustAnim.Mono;
using CustAnim.Mono.Interfaces;
using UnityEngine;

namespace CustAnim.Basic
{
    public class CircularJointUpdate : UpdateTick
    {
        [SerializeField] protected Transform joint;
        [SerializeField] protected Transform center;
        [SerializeField] protected Transform axis;
        [Space]
        [SerializeField] protected float speed = 1f;

        public override void Tick()
        {
            joint.RotateAround(center.position, axis.localPosition, speed * Time.deltaTime);
        }
    }
}
