using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Npgsql;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var testData = ValueMaker.makeValues(1000);

            var sqlCommand = "SELECT * FROM arrayastabletest";
            var sqlRunner = new SqlRunner();
            string b;
            var testList = new List<string>();
            new Tester(()=>sqlRunner.runQuery(sqlCommand), 10000, "SQL test").test().printResult();
            new Tester(()=>sqlRunner.runQueryFull(sqlCommand), 10000, "SQL test").test().printResult();

            new Tester(() => {foreach(var str in testData){}}, 10000, "inMem Arr Test").test().printResult();
            new Tester(() => {foreach(var str in testData){testList.Add(str+"a");}}, 10000, "inMem Arr Test + instantiate var").test().printResult();

            var selectCmd = "SELECT string FROM arrayastabletest where string = 'string800'";
            new Tester(()=>sqlRunner.runQueryFull(selectCmd), 10000, "SQL test select where").test().printResult();
            new Tester(() => { testData.Select((i) => i == "string800");}, 10000, "inMem Arr Test select where").test().printResult();


        }
    }


    
    
    
}