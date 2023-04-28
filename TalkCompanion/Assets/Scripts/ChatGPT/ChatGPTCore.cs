using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

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
            List<Message> msgList = new List<Message>();
            Message msg = Message.Generate(ETalkerRole.User, message);
            if (this.enableTalkContext)
            {
                // 会話コンテキスト
                msgList.AddRange(this.talkContexts);
                this.talkContexts.Add(msg);
            }
            msgList.Add(msg);

            // TODO: APIコールの実装
            await UniTask.Delay(1000);  // Warning回避用に一応
            return "";
        }
    }
}
