using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace ForestHero.Game.Characters.Modules
{
	public class AnimatorModule : MonoBehaviour
	{
		private static readonly int START_MOVE = Animator.StringToHash("startMove");
		private static readonly int CANCEL_MOVE = Animator.StringToHash("cancelMove");
		private static readonly int ON_GROUND = Animator.StringToHash("onGround");

		[SerializeField] private Animator animator;
		[SerializeField] private int attackAnimationsCount = 3; //todo: to character settings

		private MovementModule _movementModule;
		private PlayerInputActions _playerInputActions;
		private Character _character;

		[Inject]
		private void Construct(Character character)
		{
			_character = character;
			_playerInputActions = character.InputActions;
		}

		private void Awake()
		{
			_playerInputActions.Player.Movement.started += OnMovementStarted;
			_playerInputActions.Player.Movement.canceled += OnMovementCanceled;
		}

		private void Update()
		{
			animator.SetBool(ON_GROUND, _character.MovementModule.OnGround);
		}

		private void OnMovementStarted(InputAction.CallbackContext context) => 
			animator.SetTrigger(START_MOVE);
		
		private void OnMovementCanceled(InputAction.CallbackContext context) => 
			animator.SetTrigger(CANCEL_MOVE);
	}
}