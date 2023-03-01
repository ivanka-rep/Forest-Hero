using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace ForestHero.Game.Characters.Modules
{
	public class AnimatorModule : MonoBehaviour
	{
		private const float MOVEMENT_CHANGE_SPEED = 15f;
		
		private static readonly int MOVE_MAGNITUDE = Animator.StringToHash("MoveMagnitude");
		private static readonly int ON_GROUND = Animator.StringToHash("onGround");
		private static readonly int ATTACK = Animator.StringToHash("attack");
		private static readonly int ATTACK_TRIGGER = Animator.StringToHash("attackTrigger");
		

		[SerializeField] private Animator animator;
		[SerializeField] private int attackAnimationsCount = 3; //todo: to character settings
		
		private PlayerInputActions _playerInputActions;
		private Character _character;
		
		private bool _isMoving;
		private float _movementMagnitude;
		private Vector2 _moveAxis;

		[Inject]
		private void Construct(Character character)
		{
			_character = character;
			_playerInputActions = character.InputActions;
		}

		private void Awake()
		{
			_playerInputActions.Player.Attack.performed += OnAttack;
		}

		private void OnDestroy()
		{
			_playerInputActions.Player.Attack.performed -= OnAttack;

		}

		private void Update()
		{
			_moveAxis = _playerInputActions.Player.Movement.ReadValue<Vector2>();
			_movementMagnitude = Mathf.Lerp(_movementMagnitude, Mathf.Min(_moveAxis.magnitude, 1f), Time.deltaTime * MOVEMENT_CHANGE_SPEED);

			animator.SetFloat(MOVE_MAGNITUDE, _movementMagnitude);
			
			animator.SetBool(ON_GROUND, _character.MovementModule.OnGround);
		}

		private void OnAttack(InputAction.CallbackContext context)
		{
			animator.SetInteger(ATTACK, Random.Range(0, attackAnimationsCount) + 1);
			animator.SetTrigger(ATTACK_TRIGGER);
		}
	}
}