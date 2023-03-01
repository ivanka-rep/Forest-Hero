using UnityEngine;

namespace ForestHero.Game.Animations
{
	public class CombatBehaviour : StateMachineBehaviour
	{
		public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			animator.SetLayerWeight(layerIndex, 1f);
		}

		public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			animator.SetLayerWeight(layerIndex, 0f);
		}

		public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) { }

		public override void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) { }

		public override void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) { }
	}
}