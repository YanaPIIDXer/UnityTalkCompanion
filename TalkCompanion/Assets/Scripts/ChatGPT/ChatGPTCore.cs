using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.Networking;

namespace TalkCompanion.ChatGPT
{
    /// <summary>
    /// ChatGPTのコア
    /// </summary>
    public class ChatGPTCore
    {
        /// <summary>
        /// APIのエンドポイント
        /// </summary>
        private readonly string apiEndpoint = "https://api.openai.com/v1/chat/completions";

        /// <summary>
        /// 会話コンテキストを有効にするか？
        /// </summary>
        private readonly bool enableTalkContext;

        /// <summary>
        /// APIトークン
        /// </summary>
        private readonly string apiToken;

        /// <summary>
        /// 会話コンテキスト
        /// </summary>
        private List<Message> talkContexts = new List<Message>();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="apiToken">APIトークン</param>
        /// <param name="enableTalkContext">会話コンテキストを有効にするか？</param>
        public ChatGPTCore(string apiToken, bool enableTalkContext)
        {
            this.apiToken = apiToken;
            this.enableTalkContext = enableTalkContext;
        }

        /// <summary>
        /// 発言する
        /// </summary>
        /// <param name="message">発言内容</param>
        public async UniTask<string> Say(string message)
        {
            List<Dictionary<string, string>> msgList = new List<Dictionary<string, string>>();
            Message msg = Message.Generate(ETalkerRole.User, message);
            if (this.enableTalkContext)
            {
                // 会話コンテキスト
                this.talkContexts.ForEach(m =>
                {
                    msgList.Add(m.ToDictionary());
                });
                this.talkContexts.Add(msg);
            }
            msgList.Add(msg.ToDictionary());

            Dictionary<string, string> header = new Dictionary<string, string>() {
                { "Authorization", "Bearer " + this.apiToken },
                { "Content-Type", "application/json" },
            };
            Dictionary<string, string> body = new Dictionary<string, string>() {
                { "model", "gpt-3.5-turbo" },
                { "messages", msgList.ToString() },
            };
            string bodyJson = JsonUtility.ToJson(body);
            Debug.Log(bodyJson);
            return bodyJson;
        }
    }
}
