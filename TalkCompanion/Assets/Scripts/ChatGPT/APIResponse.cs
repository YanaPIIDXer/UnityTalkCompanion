using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace TalkCompanion.ChatGPT
{
    /// <summary>
    /// APIレスポンス
    /// </summary>
    [Serializable]
    public class APIResponse
    {
        [Serializable]
        public class Choice
        {
            public int index;
            public Message message;
            public string finish_reason;
        }

        [Serializable]
        public class Usage
        {
            public int prompt_tokens;
            public int completion_tokens;
            public int total_tokens;
        }

        public string id;
        public string @object;
        public int created;
        public Choice[] choices;
        public Usage usage;
    }
}
