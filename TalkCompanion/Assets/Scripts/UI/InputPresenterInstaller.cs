using UnityEngine;
using Zenject;

namespace TalkCompanion.UI
{
    /// <summary>
    /// InputPresenter Installer
    /// </summary>
    public class InputPresenterInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IInputPresenter>()
                     .FromComponentInHierarchy()
                     .AsCached();
        }
    }
}
