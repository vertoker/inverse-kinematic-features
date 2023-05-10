using UnityEngine;

namespace CustAnim.Editor
{
    public class ShowAttribute : PropertyAttribute
    {
        private ActionOnConditionFail _action;
        private InverseCondition _inverse;
        private string _condition;

        public ActionOnConditionFail Action => _action;
        public InverseCondition Inserse => _inverse;
        public string Condition => _condition;

        public ShowAttribute(ActionOnConditionFail @action, InverseCondition @inverse, string @condition)
        {
            _action = @action;
            _inverse = @inverse;
            _condition = @condition;
        }
    }
    public enum InverseCondition { No, Yes }
    public enum ActionOnConditionFail { DoNotDraw, Disable }
}