using StackExchange.Redis;
using System;

namespace AtlassianDA.Implementation
{
    public class RedisConnectorHelper
    {
        static RedisConnectorHelper()
        {
            RedisConnectorHelper.lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                ConfigurationOptions option = new ConfigurationOptions();
                option.AbortOnConnectFail = false;
                option.EndPoints.Add("myname.redis.cache.windows.net");
                option.Ssl = true;
                option.SetDefaultPorts();
                              

                return ConnectionMultiplexer.Connect(option);
            });
        }

        private static Lazy<ConnectionMultiplexer> lazyConnection;

        public static ConnectionMultiplexer Connection
        {
            get
            {
                return lazyConnection.Value;
            }
        }
    }
}
