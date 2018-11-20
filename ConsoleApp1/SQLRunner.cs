using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using Npgsql;

namespace ConsoleApp1
{
    class SqlRunner
    {
        public NpgsqlConnection Connection;
        public SqlRunner()
        {
            string connetionString;
            connetionString = "User ID=akharshan;Password=asd;Host=localhost;Port=5432;Database=akharshan;";
            Connection = new NpgsqlConnection(connetionString);
            Connection.Open();

            Console.WriteLine("opened " + Connection + " " + Connection.State);
        }
        public void runNonQuerys(List<string> commands)
        {
            commands.ForEach(command =>
            {
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = Connection;
                    cmd.CommandText = command;
                    cmd.ExecuteNonQuery();
                }
            });
        }

        
        public void runQuerys(List<string> commands)
        {
            commands.ForEach(command => runQuery(command));
        }
        public void runQuery(string command)
        {
            using (var cmd = new NpgsqlCommand())
            {
                cmd.Connection = Connection;
                cmd.CommandText = command;
                using (var reader = cmd.ExecuteReader())
                {
//                        while (reader.HasRows)
//                        {
//                            Console.WriteLine("\t{0}", reader.GetName(0));
//
//                            while (reader.Read())
//                            {
//                                Console.WriteLine("\t{0}", reader.GetString(0));
//                            }
//
//                            reader.NextResult();
//                        }
                }
            }
        }
        public void runQueryFull(string command)
        {
            using (var cmd = new NpgsqlCommand())
            {
                cmd.Connection = Connection;
                cmd.CommandText = command;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.HasRows)
                    {
                        reader.NextResult();
                    }
                }
            }
        }
        public void close()
        {
            Connection.Close();
        }

    }
}