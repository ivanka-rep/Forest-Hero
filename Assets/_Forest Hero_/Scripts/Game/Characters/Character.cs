using ForestHero.Utilities;
using UnityEngine;
using Zenject;

namespace ForestHero.Game.Characters
{
	public class Character : MonoBehaviour
	{
		private FollowCamera _followCamera;

		[Inject]
		private void Construct(FollowCamera followCamera)
		{
			_followCamera = followCamera;
		}
		
		private void Start()
		{
			_followCamera.SetNewTarget(transform);
		}
	}
}