using System;
using System.Collections.Generic;
using System.IO;

namespace MyPayProject
{
    class Program
    {
        static void Main(string[] args)
        {

            string fileName = @"import\employee-payroll-data.csv";

            //List<PayRecord> PayRecords = new List<PayRecord>();

            //PayRecords = CsvImporter.ImportPayRecords(fileName);
            //Console.WriteLine(PayRecords.Count);

            //foreach (PayRecord rec in PayRecords) {
            //    Console.WriteLine(rec.GetDetails());
            //}
            //Console.ReadKey(); 


            List<PayRecord> payRecords = new List<PayRecord>();
            payRecords = CsvImporter.ImportPayRecords(fileName);

            PayRecordWriter.Write(payRecords, true);  

        }
    }
}
