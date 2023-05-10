using System.Collections.Generic;
using CustAnim.Editor;
using CustAnim.Mono;
using CustAnim.Mono.Interfaces;
using UnityEngine;

namespace CustAnim.Basic
{
    public class TowardPointsUpdate : UpdateTick, IInitialize
    {
        [SerializeField] protected float speed = 1f;
        [SerializeField] protected List<Vector3> points;
        [SerializeField] protected int currentTarget;
        [Space]
        [SerializeField] protected bool initializeOnAwake = true;
        [Show(ActionOnConditionFail.DoNotDraw, InverseCondition.No, "initializeOnAwake")]
        [SerializeField] protected Transform self;
        
        private void Awake()
        {
            if (initializeOnAwake)
                Initialize();
        }
        public virtual void Initialize()
        {
            self = transform;
        }
        public override void Tick()
        {
            self.position = Vector3.MoveTowards(self.position, points[currentTarget], speed * Time.deltaTime);

            if (self.position != points[currentTarget]) return;
            
            currentTarget++;
            if (points.Count == currentTarget)
                currentTarget = 0;
        }
    }
}
