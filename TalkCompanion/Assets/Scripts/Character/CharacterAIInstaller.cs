using UnityEngine;
using Zenject;

namespace TalkCompanion.Character
{
    /// <summary>
    /// CharacterAIインタフェース Installer
    /// </summary>
    public class CharacterAIInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ICharacterAI>()
                     .FromComponentInHierarchy()
                     .AsCached();
        }
    }
}
