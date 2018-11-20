using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Npgsql;


namespace ConsoleApp1
{
    public static class ValueMaker
    {
        public static void initValues(int numValues)
        {
            var commandStrings = new List<String>();
            var values = makeValues(numValues);
            for (var i = 0; i < numValues; i++)
            {
                var val = values[i];
                commandStrings.Add(
                    $"INSERT INTO arrayastabletest (string) VALUES ('{val}')"                
                );
                Console.WriteLine(commandStrings[i]);
                commandStrings.Add(
                    $"INSERT INTO arrayastableindexedtest (string) VALUES ('{val}')"                
                );
            }

            var tester = new SqlRunner();
            tester.runNonQuerys(commandStrings);
        }

        public static string[] makeValues(int numToMake)
        {
            var values = new string[numToMake];
            for (var i = 0; i < numToMake; i++)
            {
                values[i] = "string" + i.ToString();
            }
            return values;
        }
    }
}