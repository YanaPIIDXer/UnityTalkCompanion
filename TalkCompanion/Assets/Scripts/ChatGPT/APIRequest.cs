using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace TalkCompanion.ChatGPT
{
    /// <summary>
    /// APIリクエスト
    /// </summary>
    [Serializable]
    public class APIRequest
    {
        /// <summary>
        /// モデル
        /// </summary>
        public string model = "gpt-3.5-turbo";

        /// <summary>
        /// メッセージ配列
        /// </summary>
        public List<Message> messages = new List<Message>();
    }
}
