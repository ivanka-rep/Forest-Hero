using Cinemachine;
using UnityEngine;

namespace ForestHero.Utilities
{
	public class FollowCamera : MonoBehaviour
	{
		[SerializeField] private CinemachineVirtualCamera followCamera;
		[SerializeField] private Transform target;

		private void Start()
		{
			if (target)
				SetNewTarget(target);
		}

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