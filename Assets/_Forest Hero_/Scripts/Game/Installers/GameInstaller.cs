using ForestHero.Game.Characters;
using ForestHero.Utilities;
using UnityEngine;
using Zenject;

namespace ForestHero.Game.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private Character character;
        [SerializeField] private FollowCamera followCamera;
        
        public override void InstallBindings()
        {
            Container.BindInstance(character).AsSingle();
            Container.BindInstance(followCamera).AsSingle();
        }
    }
}
