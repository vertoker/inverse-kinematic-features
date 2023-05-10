using System.Collections.Generic;
using CustAnim.Editor;
using CustAnim.Mono;
using CustAnim.Mono.Interfaces;
using UnityEngine;

namespace CustAnim.Basic
{
    public class TowardJointsUpdate : UpdateTick, IInitialize
    {
        [SerializeField] protected float speed = 1f;
        [Space]
        [SerializeField] protected bool initializeOnAwake = true;
        [Show(ActionOnConditionFail.DoNotDraw, InverseCondition.No, "initializeOnAwake")]
        [SerializeField] protected List<Transform> joints;
        [Show(ActionOnConditionFail.DoNotDraw, InverseCondition.No, "initializeOnAwake")]
        [SerializeField] protected int currentTarget;
        [SerializeField] protected Transform self;
        
        private void Awake()
        {
            if (initializeOnAwake)
                Initialize();
        }
        public virtual void Initialize()
        {
            joints = new List<Transform>();
            for (int i = 0; i < transform.childCount; i++)
                joints.Add(transform.GetChild(i));
        }
        public override void Tick()
        {
            self.position = Vector3.MoveTowards(self.position, joints[currentTarget].position, speed * Time.deltaTime);

            if (self.position != joints[currentTarget].position) return;
            
            currentTarget++;
            if (joints.Count == currentTarget)
                currentTarget = 0;
        }
    }
}