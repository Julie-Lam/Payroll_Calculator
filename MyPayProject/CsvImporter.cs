using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Text;

namespace MyPayProject
{
    public class CsvImporter
    {
        /// <summary>
        /// Generates a list of <PayRecord> objects containing either <ResidentPayRecord> objects or <WorkingHolidayPayRecord>, as appropriate for the emplopyee type.  
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static List<PayRecord> ImportPayRecords(string file)
        {
            //GOAL: Generate a list of <PayRecord objects>. A pay record should be UNIQUE for ea. employee
            List<PayRecord> payRecords = new List<PayRecord>(); 
            
            //1. Import the csv file 
                //1.i) variables 
            List<string> recs = new List<string>(); // For list of recordLines 
            string recordLine; // For a line from the csv file 

            StreamReader reader = new StreamReader(file); //the reader object so we can manip. the file 

            //2. Read the csv file
                //2.i) Read a line of the csv file until we get to the content
            recordLine = reader.ReadLine(); // returns headings 
            recordLine = reader.ReadLine(); // actual record starts here

                //2.ii) Iterate through each additional line in the file until all rows have been read
            while (recordLine != null)
            {
                recs.Add(recordLine); //add the current recordLine to the recs list

                recordLine = reader.ReadLine(); //read the next line. 
            }
            reader.Close();

            //3. Assign the initial value for currentEmployeeId, hours array, rates array, and visa (if applicable)
                //3.i) variables 
            int currentEmployeeId;
            string[] currentRecordArray;

            double[] hours = new double[10];
            double[] rates = new double[10];
            int counter = 0; 

            int visa = 0;
            int yearToDate = 0;

                //3.ii) Convert first line of recs into an array 
            currentRecordArray = recs[0].Split(",");

                //3. iii) Set the currentEmployeeId to the first Id value, add the first hour value to the array, add the first rate value to the array
            currentEmployeeId = int.Parse(currentRecordArray[counter]);
            hours[counter] = double.Parse(currentRecordArray[1]);
            rates[counter] = double.Parse(currentRecordArray[2]);

                //3.vi) Set the first visa value, if it is available 
            if (currentRecordArray[3] != "")
            {
                visa = int.Parse(currentRecordArray[3]);
                yearToDate = int.Parse(currentRecordArray[4]);
            }

            counter++;

            //4. Loop through the next line, check if employee id is the same. If so, add the id, hours and rates to the same PayRecord object. 
            for (int i = 1; i < recs.Count; i++)
            {
                currentRecordArray = recs[i].Split(",");

                // 4. i) If next line is a NEW employee
                if (int.Parse(currentRecordArray[0]) != currentEmployeeId )
                {
                    //Determine the TYPE of employee for current line
                    if (visa != 0)
                    {
                        payRecords.Add(new WorkingHolidayPayRecord(currentEmployeeId, hours, rates, visa, yearToDate));

                        visa = 0; //reset the visa value 
                    }

                    else {
                        payRecords.Add(new ResidentPayRecord(currentEmployeeId, hours, rates));
                    }

                    currentEmployeeId = int.Parse(currentRecordArray[0]); //Set the new employee Id as the current Id 

                    //Reset the arrays and counter
                    hours = new double[10]; 
                    rates = new double[10]; 
                    counter = 0; 

                    //Assign the next line's visa value, if applicable 
                    if (currentRecordArray[3] != "")
                    {
                        visa = int.Parse(currentRecordArray[3]);
                        yearToDate = int.Parse(currentRecordArray[4]);
                    }

                    hours[counter] = double.Parse(currentRecordArray[1]);
                    rates[counter] = double.Parse(currentRecordArray[2]);
                    counter++;
                }
                
                // 4.ii) If next line is the SAME employee 
                else if (int.Parse(currentRecordArray[0]) == currentEmployeeId)
                {
                    hours[counter] = double.Parse(currentRecordArray[1]);
                    rates[counter] = double.Parse(currentRecordArray[2]);
                    counter++;

                    if (i == recs.Count - 1) {
                        payRecords.Add(new ResidentPayRecord(currentEmployeeId, hours, rates));
                    }
                }
            }

            return payRecords; 
        }

        //public static void createPayRecord(int id, double[] hours, double[] rates, int visa, int yearToDate)
        //{

        //}

    }

}
