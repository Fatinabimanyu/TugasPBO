using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace PesenMinum
{
    class Program
    {
        static string connectionstring =  "server=localhost; port=3306; uid=Fatinn; database=database_pesenminum; charset=utf8; sslMode=none;";
                                            
        static MySqlConnection connecction = new MySqlConnection(connectionstring);
        static void Main(string[] args)
        {
            Console.WriteLine("Connect to MySql DB. \n");

            using(connecction)
            {
                try{
                    connecction.Open();
                    System.Console.WriteLine("Connection is " + connecction.State.ToString()+ Environment.NewLine);

                    MySqlCommand command = connecction.CreateCommand();
                    command.CommandText = System.Data.CommandType.Text.ToString();
                    command.CommandText = "Select * from pesenminum_database";

                    MySqlDataReader reader = command.ExecuteReader();
                    var data = "[id]\t[name]\t[jenisminuman]\n";

                    if(reader.HasRows)
                    {
                        while(reader.Read())
                        {
                            data += reader.GetInt32(0)+"\t" + reader.GetString(1)+ "\t"
                            + reader.GetString(2)+ Environment.NewLine;
                        }
                        Console.WriteLine(data);
                         
                    }else{
                        Console.WriteLine("-- Data empty -- ");
                    }
                    reader.Close();
                    connecction.Close();
                    System.Console.WriteLine("Connection is " + connecction.State.ToString()+ Environment.NewLine);

                } catch (MySql.Data.MySqlClient.MySqlException ex){
                    System.Console.WriteLine("Error: " + ex.Message.ToString());

                } finally{
                    System.Console.WriteLine("Press any key to exit...");
                    Console.ReadKey();
                }
            }
            

        }
    }
}
