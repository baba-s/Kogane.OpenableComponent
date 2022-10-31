using System;
using UnityEngine;

namespace Kogane
{
    /// <summary>
    /// 開閉できるコンポーネント
    /// </summary>
    [DisallowMultipleComponent]
    public sealed class OpenableComponent : MonoBehaviour
    {
        //================================================================================
        // 変数
        //================================================================================
        [SerializeField][HideInInspector] private bool m_isInitialized;

        //================================================================================
        // 関数
        //================================================================================
        /// <summary>
        /// 初期化される時に呼び出されます
        /// </summary>
        private void Awake()
        {
            Initialize();
        }

        /// <summary>
        /// 初期化します
        /// </summary>
        public void Initialize()
        {
            if ( m_isInitialized ) return;
            m_isInitialized = true;

            gameObject.SetActive( false );
        }

        /// <summary>
        /// 開きます
        /// </summary>
        public IDisposable Open()
        {
            Initialize();
            gameObject.SetActive( true );
            return Disposable.Create( () => gameObject.SetActive( false ) );
        }

        /// <summary>
        /// 閉じます
        /// </summary>
        public void Close()
        {
            Initialize();
            gameObject.SetActive( false );
        }
    }
}