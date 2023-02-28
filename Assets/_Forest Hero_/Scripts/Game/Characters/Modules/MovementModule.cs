using UnityEngine;
using Zenject;

namespace ForestHero.Game.Characters.Modules
{
	public class MovementModule : MonoBehaviour
	{
		[SerializeField] private CharacterController controller;

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
			
		}
	}
}