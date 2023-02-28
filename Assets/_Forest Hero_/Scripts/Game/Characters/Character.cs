using ForestHero.Game.Characters.Modules;
using ForestHero.Utilities;
using UnityEngine;
using Zenject;

namespace ForestHero.Game.Characters
{
	public class Character : MonoBehaviour
	{
		public PlayerInputActions InputActions => _playerInputActions;
		public MovementModule MovementModule => _movementModule;
		
		private PlayerInputActions _playerInputActions;
		private FollowCamera _followCamera;
		private MovementModule _movementModule;

		[Inject]
		private void Construct(FollowCamera followCamera)
		{
			_followCamera = followCamera;
			_playerInputActions = new PlayerInputActions();
			_playerInputActions.Enable();

			_movementModule = gameObject.GetComponent<MovementModule>();
		}
		
		private void Awake()
		{
			_followCamera.SetNewTarget(transform);
		}
		
		private void OnDestroy()
		{
			_playerInputActions?.Disable();
		}
	}
}