using Newtonsoft.Json;
using RedisConsoleSample.Models;
using RedisConsoleSample.Utils;
using System.Diagnostics;

namespace RedisConsoleSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var ret = RedisUtil.ExecutePing();
            Debug.WriteLine(ret);

            RedisUtil.SetMessage("Test", "This is Test Message!!");

            ret = RedisUtil.GetMessage("Test");
            Debug.WriteLine(ret);

            ret = RedisUtil.ExecuteClientList();
            Debug.WriteLine(ret);

            // .NETクラスの保存・取得をテスト
            var emp = new Employee() { Id = "001", Age = 20, Name = "Yamada Taro"};
            RedisUtil.SetMessage("001", JsonConvert.SerializeObject(emp));

            var remp = JsonConvert.DeserializeObject<Employee>(RedisUtil.GetMessage("001"));
            Debug.WriteLine("Deserialized Employee .NET object :\n");
            Debug.WriteLine("\tEmployee.Name : " + remp.Name);
            Debug.WriteLine("\tEmployee.Id   : " + remp.Id);
            Debug.WriteLine("\tEmployee.Age  : " + remp.Age + "\n");
        }
    }
}
