using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TalkCompanion.ChatGPT;
using TalkCompanion.Env;

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

        async void Start()
        {
            string response = await gptCore.Say("TypeScriptでHello, Worldを書いてください");
            Debug.Log(response);
        }
    }
}