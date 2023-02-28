using UnityEngine;
using Zenject;

namespace ForestHero.Game.Characters.Modules
{
	public class MovementModule : MonoBehaviour
	{
		[SerializeField] private new Rigidbody rigidbody;
		[SerializeField] private new Collider collider;
		
		[Header("Movement settings")]
		[SerializeField] private float moveSpeed = 15f;
		[SerializeField] private float stopSpeed = 15f;
		[SerializeField, Range(0f, 15f)] private float turnSpeed = 15f;
		
		private PlayerInputActions _playerInputActions;
		private Character _character;
		private readonly Collider[] _groundCheckColliders = new Collider[15];
		private bool _isOnGround;

		[Inject]
		private void Construct(Character character)
		{
			_character = character;
			_playerInputActions = new PlayerInputActions();
		}

		private void Awake()
		{
			_playerInputActions.Player.Enable();
		}
		
		private void FixedUpdate()
		{
			GroundCheck();
			
			if(_isOnGround)
				CalculateMovement();
		}

		private void CalculateMovement()
		{
			if (!_playerInputActions.Player.Movement.inProgress)
			{
				rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, Vector3.zero, Time.fixedDeltaTime * stopSpeed);
				return;
			}
			
			Vector2 moveAxis = _playerInputActions.Player.Movement.ReadValue<Vector2>();
			Vector3 moveDirection = new(moveAxis.x, 0, moveAxis.y);

			MoveCharacter(moveDirection);
			TurnTowardsDirection(moveDirection);
		}

		private void MoveCharacter(Vector3 direction)
		{
			Vector3 targetVelocity = direction * moveSpeed;
			rigidbody.velocity = targetVelocity;
		}

		private void TurnTowardsDirection(Vector3 direction)
		{
			Quaternion lookRotation = Quaternion.LookRotation(direction, Vector3.up);
			transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, turnSpeed * Time.deltaTime);
		}

		private void GroundCheck()
		{
			_isOnGround = Physics.CheckSphere(transform.position, 1f, LayerMask.GetMask("Ground"));
		}
	}
}