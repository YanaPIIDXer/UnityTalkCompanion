using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TalkCompanion.ChatGPT;
using TalkCompanion.Env;
using TalkCompanion.UI;
using Zenject;
using UniRx;
using System;

namespace TalkCompanion.Character
{
    /// <summary>
    /// AIインタフェース
    /// </summary>
    public interface ICharacterAI
    {
        /// <summary>
        /// レスポンスを受け取った
        /// </summary>
        public IObservable<string> onResponse { get; }
    }

    /// <summary>
    /// キャラクタAIクラス
    /// </summary>
    public class CharacterAI : MonoBehaviour, ICharacterAI
    {
        /// <summary>
        /// ChatGPTのコア
        /// </summary>
        private ChatGPTCore gptCore = new ChatGPTCore(Env.Environment.Instance.OpenAIToken, true);

        /// <summary>
        /// レスポンスを受け取った時のSubject
        /// </summary>
        private Subject<string> onResponseSubject = new Subject<string>();

        /// <summary>
        /// レスポンスを受け取った
        /// </summary>
        public IObservable<string> onResponse => onResponseSubject;

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
                              onResponseSubject.OnNext(response);
                          }).AddTo(gameObject);
        }
    }
}
