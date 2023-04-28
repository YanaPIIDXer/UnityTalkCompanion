using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.Networking;
using System;
using System.Text;

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
            APIRequest request = new APIRequest();
            Message msg = Message.Generate(ETalkerRole.User, message);
            if (this.enableTalkContext)
            {
                // 会話コンテキスト
                request.messages.AddRange(this.talkContexts);
                this.talkContexts.Add(msg);
            }
            request.messages.Add(msg);

            Dictionary<string, string> headers = new Dictionary<string, string>() {
                { "Authorization", "Bearer " + this.apiToken },
                { "Content-Type", "application/json" },
            };

            string bodyJson = JsonUtility.ToJson(request);

            using var apiRequest = new UnityWebRequest(this.apiEndpoint, "POST")
            {
                uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(bodyJson)),
                downloadHandler = new DownloadHandlerBuffer()
            };

            foreach (var header in headers)
            {
                apiRequest.SetRequestHeader(header.Key, header.Value);
            }

            await apiRequest.SendWebRequest();


            if (apiRequest.result == UnityWebRequest.Result.ConnectionError ||
                apiRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError(apiRequest.error);
                throw new Exception(apiRequest.error.ToString());
            }


            var responseString = apiRequest.downloadHandler.text;
            // TODO: レスポンスをパースして発言だけ取り出す処理の実装
            return responseString;
        }
    }
}
