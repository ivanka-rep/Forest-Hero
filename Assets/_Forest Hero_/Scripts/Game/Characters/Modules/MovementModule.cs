using UnityEngine;
using Zenject;

namespace ForestHero.Game.Characters.Modules
{
	public class MovementModule : MonoBehaviour
	{
		[SerializeField] private CharacterController characterController;

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
		
		private void Update()
		{
			MoveCharacter();
		}

		private void MoveCharacter()
		{
			Vector2 moveAxis = _playerInputEvents.Player.Movement.ReadValue<Vector2>();
			
			if(moveAxis == Vector2.zero)
				return;

			Vector3 direction = new(moveAxis.x, 0, moveAxis.y);

			const float speed = 25f;
			
			characterController.SimpleMove(direction * speed);
			
			Quaternion lookRotation = Quaternion.LookRotation(direction, Vector3.up); 
			
			_character.transform.rotation = Quaternion.Lerp(_character.transform.rotation, lookRotation, speed * Time.deltaTime);
		}
	}
}