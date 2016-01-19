using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisPresureTest
{
    public class TestorGetAll : AbstractTestor
    {
        public override void Test()
        {
            var client = RedisManager.GetCacheClient();
            var key1 = "abc12345678910";
            var key2 = "bbbb12345678910";
            client.Set(key1, "my name is binbin");
            client.Set(key2, "my name is binbin2");
            var keys = new List<string> { key1, key2 };
            var values = client.GetAll<string>(keys);
        }
    }
}
