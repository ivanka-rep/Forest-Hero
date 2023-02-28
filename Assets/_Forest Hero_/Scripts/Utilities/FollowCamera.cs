using Cinemachine;
using UnityEngine;

namespace ForestHero.Utilities
{
	public class FollowCamera : MonoBehaviour
	{
		[SerializeField] private CinemachineVirtualCamera followCamera;

		public Camera Camera { get; private set; }

		public Vector3 PositionOffset => followCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset;

		private void Awake()
		{
			Camera = GetComponentInChildren<Camera>();
		}

		public void SetNewTarget(Transform player)
		{
			followCamera.transform.position = player.position + PositionOffset;
			followCamera.Follow = player;
		}
	}
}