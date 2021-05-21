using Microsoft.AspNetCore.Mvc;
using System.Data.OleDb;

namespace RPC_api_client_ser5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class takeSoketDBSave : Controller
    {
        [HttpPost]
        public string Post(CBRCurrency cbr)
        {
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=db.mdb";//строка соеденения
            OleDbConnection dbConnection = new OleDbConnection(connectionString);//создаем соеденение

            //Выполянем запрос к БД
            dbConnection.Open();//открываем соеденение

            string query = $"INSERT INTO curdata (data) VALUES ('{cbr.data}')";

            OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);//команда
            OleDbCommand command = new OleDbCommand(query, dbConnection);

            // выполняем запрос к MS Access
            command.ExecuteReader(); 

            dbConnection.Close();
            return "ok";
        }

        
    }
    public class CBRCurrency
    {
        public string data { get; set; }
    }
}
