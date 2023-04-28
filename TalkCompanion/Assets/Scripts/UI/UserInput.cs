using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UniRx;
using System;

namespace TalkCompanion.UI
{
    /// <summary>
    /// ユーザ入力
    /// </summary>
    public class UserInput : MonoBehaviour
    {
        /// <summary>
        /// テキストフォーム
        /// </summary>
        [SerializeField]
        private TMP_InputField inputText;

        /// <summary>
        /// 送信ボタン
        /// </summary>
        [SerializeField]
        private Button submitButton;

        /// <summary>
        /// 送信Subject
        /// </summary>
        private Subject<string> onSubmitSubject = new Subject<string>();

        /// <summary>
        /// 送信イベントのObservable
        /// </summary>
        public IObservable<string> onSubmit => onSubmitSubject;

        void Awake()
        {
            submitButton.OnClickAsObservable()
                        .Where(_ => inputText.text != "")
                        .Subscribe(_ =>
                        {
                            onSubmitSubject.OnNext(inputText.text);
                            inputText.text = "";
                        }).AddTo(gameObject);
        }
    }
}

