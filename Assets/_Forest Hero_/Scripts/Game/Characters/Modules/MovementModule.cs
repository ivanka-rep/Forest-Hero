using UnityEngine;
using Zenject;

namespace ForestHero.Game.Characters.Modules
{
	public class MovementModule : MonoBehaviour
	{
		[SerializeField] private new Rigidbody rigidbody;
		
		[Header("Movement settings")]
		[SerializeField] private float acceleration = 1f;
		[SerializeField] private float maxSpeed = 10f;
		[SerializeField, Range(0f, 15f)] private float turnSpeed = 15f;
		
		private PlayerInputActions _playerInputEvents;
		private Character _character;

		[Inject]
		private void Construct(Character character)
		{
			_character = character;
			_playerInputEvents = new PlayerInputActions();
		}

		private void Awake()
		{
			_playerInputEvents.Player.Enable();
		}
		
		private void FixedUpdate()
		{
			if(!_playerInputEvents.Player.Movement.inProgress)
				return;
			
			Vector2 moveAxis = _playerInputEvents.Player.Movement.ReadValue<Vector2>();
			Vector3 moveDirection = new(moveAxis.x, 0, moveAxis.y);

			MoveCharacter(moveDirection);
			TurnTowardsDirection(moveDirection);
		}

		private void MoveCharacter(Vector3 direction)
		{
			Vector3 targetVelocity = direction * acceleration;
			Vector3 currentVelocity = rigidbody.velocity;

			Vector3 velocityChange = targetVelocity - currentVelocity;
			velocityChange.y = 0f;

			velocityChange = Vector3.ClampMagnitude(velocityChange, maxSpeed);

			rigidbody.AddForce(velocityChange, ForceMode.Acceleration);
		}

		private void TurnTowardsDirection(Vector3 direction)
		{
			Quaternion lookRotation = Quaternion.LookRotation(direction, Vector3.up);
			_character.transform.rotation = Quaternion.Lerp(_character.transform.rotation, lookRotation, turnSpeed * Time.deltaTime);
		}
	}
}