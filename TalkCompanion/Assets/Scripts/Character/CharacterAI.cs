using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TalkCompanion.ChatGPT;
using TalkCompanion.Env;
using TalkCompanion.UI;
using Zenject;
using UniRx;

namespace TalkCompanion.Character
{
    /// <summary>
    /// キャラクタAIクラス
    /// </summary>
    public class CharacterAI : MonoBehaviour
    {
        /// <summary>
        /// ChatGPTのコア
        /// </summary>
        private ChatGPTCore gptCore = new ChatGPTCore(Environment.Instance.OpenAIToken, true);

        /// <summary>
        /// InputPresenterのInject
        /// </summary>
        /// <param name="inputPresenter">InputPresenter</param>
        [Inject]
        public void OnInjectInputPresenter(IInputPresenter inputPresenter)
        {
            inputPresenter.onUserSubmit
                          .Subscribe(async (message) =>
                          {
                              string response = await gptCore.Say(message);
                              Debug.Log(response);
                          }).AddTo(gameObject);
        }
    }
}
