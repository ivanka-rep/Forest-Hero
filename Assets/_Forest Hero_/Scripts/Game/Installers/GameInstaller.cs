using ForestHero.Game.Characters;
using UnityEngine;
using Zenject;

namespace ForestHero.Game.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private Character character;
        
        public override void InstallBindings()
        {
            Container.BindInstance(character).AsSingle();
        }
    }
}
