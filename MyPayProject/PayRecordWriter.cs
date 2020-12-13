using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace MyPayProject
{
    class PayRecordWriter
    {
        /// <summary>
        /// Writes the employee Id, gross, net and tax amounts for each employee to a CSV file and also prints results to console 
        /// </summary>
        /// <param name="payRecords"></param>
        /// <param name="writeToConsole"></param>
        static public void Write(List<PayRecord> payRecords, bool writeToConsole) {
            string fileName = DateTime.Now.Ticks + "-records.csv";
            string filePath = @"Export\" + fileName; 
               

            //1. Write ID, Gross, Net and Tax amounts to comma delimited file
            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                foreach (PayRecord rec in payRecords)
                {
                    csv.WriteRecords(payRecords); 
                }
            }
 
            //2. Write to console 
            if (writeToConsole == true) {
                foreach (PayRecord rec in payRecords)
                {
                    Console.WriteLine(rec.GetDetails() + "\n");
                }
            }
        }
    }
}
