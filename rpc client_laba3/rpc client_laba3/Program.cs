using Grpc.Net.Client;
using rpc_laba3;
using System;
using System.Data.OleDb;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;

namespace rpc_client_laba3
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Для продолжения цепочки нажмите на любую кнопку");
            Console.ReadKey();
            using var channel = GrpcChannel.ForAddress("https://localhost:5001/");
            var client = new Greeter.GreeterClient(channel);

            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\aleks\Desktop\лабы архитектура ИС\лаба 3\RPC-api-client-ser5\RPC-api-client-ser5\db.mdb";//строка соеденения
            OleDbConnection dbConnection = new OleDbConnection(connectionString);//создаем соеденение

            dbConnection.Open();//открываем соеденение

           
                string query = "SELECT * FROM curdata";

                OleDbCommand command = new OleDbCommand(query, dbConnection);

                // выполняем запрос к MS Access
               // string res = command.ExecuteScalar().ToString();
                OleDbDataReader reader = command.ExecuteReader();
                try
                {
                Console.WriteLine("Связь установлена, подгружаем из бд");
                while (reader.Read())
                    {
                    
                        // выводим данные столбцов текущей строки в listBox1
                    var reply = await client.SayHelloAsync(new HelloRequest() { Name = reader[1].ToString() });
                }
                }
                catch (Exception ex)
                {
                Console.WriteLine(ex);
                }
            Console.WriteLine("Сообщение отправлено");
               
                Thread.Sleep(10000);
               
            
            dbConnection.Close();

            


            //
        }
    }
}
