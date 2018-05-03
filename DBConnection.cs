using System;
using System.Data.SQLite;
using System.Collections.Generic;
namespace TP_Command_Pattern
{
    public class DBConnection
    {
        private static DBConnection instance;

        // Ces fausses données ne sont que pour simuler l'accès à une source de données externes, 
        // ce n'est pas le propos de ce projet qui présente simplement le pattern Singleton
        private SQLiteConnection connection;

        private DBConnection()
        {
            // établissement de la connexion à la BDD
            SQLiteConnection.CreateFile("TP_Database.sqlite");
            connection = new SQLiteConnection("Data Source=TP_Database.sqlite;Version=3;");
            connection.Open();
            string sql = "create table stocks (ID int, name varchar(50), quantity int, state varchar(50))";
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            command.ExecuteNonQuery();
        }

        // Cette méthode instancie l'UNIQUE instance de DBConnection du projet, 
        // au besoin lors du premier appel à la méthode GetInstance()
        public static DBConnection GetInstance()
        {
            if (instance == null)
                instance = new DBConnection();
            return instance;
        }

        public void Add(Stock stock)
        {
            string sql = "insert into stocks (ID, name, quantity, state) values ("+stock.getID()+",'"+ stock.getName()+"',"+ stock.getQuantity()+", '"+ stock.getState()+"')";
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            command.ExecuteNonQuery();
           // connection.theData.Add(newValue);
        }

       /* public void Update(string oldValue, string newValue)
        {
            //var nbErased = connection.theData.RemoveAll(o => o.Equals(oldValue));
            //for (int i = 0; i < nbErased; i++)
                connection.theData.Add(newValue);
        }

        public int Delete(string valueToRemove)
        {
            return connection.theData.RemoveAll(o => o.Equals(valueToRemove));
        }

        public List<string> GetAll()
        {
            return connection.theData;
        }*/

        public void Delete(Stock stock){
            string sql = "DELETE FROM stocks WHERE ID = "+stock.getID();
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            command.ExecuteNonQuery();
        }

        public void printStocks()
        {
            string sql = "select * from stocks order by quantity desc";
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
                Console.WriteLine("ID: " + reader["ID"] +"\tName: " + reader["name"] + "\tQuantity: " + reader["quantity"] 
                                  + "\tState: " + reader["state"]);
            Console.ReadLine();
        }

    }
}
