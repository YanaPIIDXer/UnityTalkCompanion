using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

namespace TalkCompanion.UI
{
    /// <summary>
    /// 入力Presenterインタフェース
    /// </summary>
    public interface IInputPresenter
    {
        IObservable<string> onUserSubmit { get; }
    }

    /// <summary>
    /// 入力Presenter
    /// </summary>
    public class InputPresenter : MonoBehaviour, IInputPresenter
    {
        /// <summary>
        /// ユーザの入力
        /// </summary>
        [SerializeField]
        private UserInput userInput;

        /// <summary>
        /// ユーザ入力Observable
        /// </summary>
        public IObservable<string> onUserSubmit => userInput.onSubmit;
    }
}
