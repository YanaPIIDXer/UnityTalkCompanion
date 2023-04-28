using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Zenject;
using TalkCompanion.Character;
using UniRx;
using System;

namespace TalkCompanion.UI
{
    /// <summary>
    /// AIのレスポンス表示
    /// </summary>
    public class AIResponse : MonoBehaviour
    {
        /// <summary>
        /// テキスト
        /// </summary>
        [SerializeField]
        private TMP_Text inputText;

        /// <summary>
        /// CharacterAIのInject
        /// </summary>
        /// <param name="characterAI">CharacterAI</param>
        [Inject]
        public void OnInjectCharacterAI(ICharacterAI characterAI)
        {
            characterAI.onResponse.Subscribe(msg =>
            {
                inputText.text = msg;
            }).AddTo(gameObject);
        }
    }
}
