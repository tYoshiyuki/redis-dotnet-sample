using StackExchange.Redis;
using System;
using System.Configuration;

namespace RedisConsoleSample.Utils
{
    public static class RedisUtil
    {
        private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            string cacheConnection = ConfigurationManager.AppSettings["CacheConnection"].ToString();
            return ConnectionMultiplexer.Connect(cacheConnection);
        });

        /// <summary>
        /// ConnectionMultiplexerの取得
        /// </summary>
        public static ConnectionMultiplexer Connection
        {
            get
            {
                return lazyConnection.Value;
            }
        }

        /// <summary>
        /// PINGコマンドの実行
        /// </summary>
        public static string ExecutePing()
        {
            return Connection.GetDatabase().Execute("PING").ToString();
        }

        /// <summary>
        /// メッセージの取得
        /// </summary>
        public static string GetMessage(string key)
        {
            return Connection.GetDatabase().StringGet(key).ToString();
        }

        /// <summary>
        /// メッセージの保存
        /// </summary>
        public static bool SetMessage(string key, string msg)
        {
            return Connection.GetDatabase().StringSet(key, msg);
        }

        /// <summary>
        /// CLIENT LISTコマンドの実行
        /// </summary>
        public static string ExecuteClientList()
        {
            return Connection.GetDatabase().Execute("CLIENT", "LIST").ToString();
        }
    }
}
