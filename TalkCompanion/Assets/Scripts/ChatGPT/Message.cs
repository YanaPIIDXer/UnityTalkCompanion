using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TalkCompanion.ChatGPT
{
    /// <summary>
    /// 発言者ロール
    /// </summary>
    public enum ETalkerRole
    {
        /// <summary>
        /// ユーザ
        /// </summary>
        User,

        /// <summary>
        /// システム
        /// </summary>
        System,

        /// <summary>
        /// アシスタント（AIによる返答）
        /// </summary>
        Assistant,
    }

    /// <summary>
    /// メッセージオブジェクトクラス
    /// </summary>
    public class Message
    {
        /// <summary>
        /// ロール
        /// </summary>
        public readonly string role;

        /// <summary>
        /// メッセージ
        /// </summary>
        public readonly string message;

        /// <summary>
        /// 生成
        /// </summary>
        /// <param name="role">ロール</param>
        /// <param name="message">メッセージ</param>
        /// <returns>Messageオブジェクト</returns>
        public static Message Generate(ETalkerRole role, string message)
        {
            switch (role)
            {
                case ETalkerRole.User:
                    return new Message("user", message);
                case ETalkerRole.System:
                    return new Message("system", message);
                case ETalkerRole.Assistant:
                    return new Message("assistant", message);
            }
            Debug.LogError("Invalid Role:" + role);
            return null;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="role">ロール</param>
        /// <param name="message">メッセージ</param>
        public Message(string role, string message)
        {
            this.role = role;
            this.message = message;
        }

        /// <summary>
        /// APIに投げるためのDictionaryに変換
        /// </summary>
        /// <returns>Dictionary</returns>
        public Dictionary<string, string> ToDictionary()
        {
            return new Dictionary<string, string>()
            {
                { "role", this.role },
                { "content", this.message },
            };
        }
    }
}
