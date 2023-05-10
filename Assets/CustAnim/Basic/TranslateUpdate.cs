using System;
using CustAnim.Editor;
using CustAnim.Mono;
using CustAnim.Mono.Interfaces;
using UnityEngine;

namespace CustAnim.Basic
{
    public class TranslateUpdate : UpdateTick, IInitialize
    {
        [SerializeField] protected Vector3 speed = new Vector3(0, 0, 0);
        [SerializeField] protected Space spaceType = Space.Self;
        [Space]
        [SerializeField] protected bool initializeOnAwake = true;
        [Show(ActionOnConditionFail.DoNotDraw, InverseCondition.No, "initializeOnAwake")]
        [SerializeField] protected Transform self;

        private void Awake()
        {
            if (initializeOnAwake)
                Initialize();
        }
        public void Initialize()
        {
            self = transform;
        }

        public override void Tick()
        {
            self.Translate(speed, spaceType);
        }
    }
}
