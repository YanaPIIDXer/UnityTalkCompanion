using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TalkCompanion.ChatGPT
{
    /// <summary>
    /// AIクラス
    /// </summary>
    public class AICore : MonoBehaviour
    {
        // APIのエンドポイント
        private readonly string apiEndpoint = "https://api.openai.com/v1/chat/completions";

        /// <summary>
        /// 発言する
        /// </summary>
        /// <param name="message">発言内容</param>
        public void Say(string message)
        {
        }
    }
}
