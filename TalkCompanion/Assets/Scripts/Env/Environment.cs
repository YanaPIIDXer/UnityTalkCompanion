using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TalkCompanion.Env
{
    /// <summary>
    /// 環境変数
    /// partialクラスとし、環境変数をブチ込むコンストラクタはgitで公開しないように別ファイルに定義する
    /// </summary>
    public partial class Environment
    {
        /// <summary>
        /// OpenAIのトークン
        /// </summary>
        public readonly string OpenAIToken { get; private set; }

        #region Singleton
        public Environment Instance { get; private set; } = new Environment();
        #endregion
    }
}