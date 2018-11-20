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

            var SelectAllCommand = "SELECT * FROM arrayastabletest";
            var sqlRunner = new SqlRunner();
            
            new Tester(()=>sqlRunner.runQuery(SelectAllCommand), 10000, "SQL test").test().printResult();
            new Tester(()=>sqlRunner.runQueryFull(SelectAllCommand), 10000, "SQL test").test().printResult();

            new Tester(() => {foreach(var str in testData){}}, 10000, "inMem Arr Test").test().printResult();
            var testList = new List<string>();
            new Tester(() => {foreach(var str in testData){testList.Add(str+"a");}}, 10000, "inMem Arr Test + instantiate var").test().printResult();

            var selectCmd = "SELECT string FROM arrayastabletest where string = 'string800'";
            var selectCmdIndexed = "SELECT string FROM arrayastableindexedtest where string = 'string800'";

            new Tester(()=>sqlRunner.runQueryFull(selectCmd), 10000, "SQL test select where").test().printResult();
            new Tester(()=>sqlRunner.runQueryFull(selectCmdIndexed), 10000, "SQL test select where with index").test().printResult();
            new Tester(() => { testData.Select((i) => i == "string800");}, 10000, "inMem Arr Test select where").test().printResult();


        }
    }


    
    
    
}