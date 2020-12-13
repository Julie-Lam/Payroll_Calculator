using NUnit.Framework;
using MyPayProject;
using System.Collections.Generic;
using System;

namespace MyPayRecordTestProject
{
    public class Tests
    {
        private List<PayRecord> _records;

        [SetUp]
        public void Setup()
        {
            _records = CsvImporter.ImportPayRecords(@"import\employee-payroll-data.csv");
        }

        [Test]
        public void TestImport() {
            Assert.IsNotNull(_records); // checks that the object is not null 
            Assert.AreEqual(_records.Count, 5); //checks that the list.Count value and 5 is the same
        }

        [Test]
        public void TestGross()
        {
            double expectedEmployeeOne = 652;
            double actualEmployeeOne = Math.Round(_records[0].Gross, 2);

            double expectedEmployeeTwo = 418;
            double actualEmployeeTwo = Math.Round(_records[1].Gross, 2);

            double expectedEmployeeThree = 2202;
            double actualEmployeeThree = Math.Round(_records[2].Gross, 2);

            double expectedEmployeeFour = 1104;
            double actualEmployeeFour = Math.Round(_records[3].Gross, 2);

            double expectedEmployeeFive = 1797.45;
            double actualEmployeeFive = Math.Round(_records[4].Gross, 2);

            Assert.AreEqual(expectedEmployeeOne, actualEmployeeOne);
            Assert.AreEqual(expectedEmployeeTwo, actualEmployeeTwo);
            Assert.AreEqual(expectedEmployeeThree, actualEmployeeThree);
            Assert.AreEqual(expectedEmployeeFour, actualEmployeeFour);
            Assert.AreEqual(expectedEmployeeFive, actualEmployeeFive);
        }

        [Test]
        public void TestTax() {
            double expectedEmployeeOne = 182.45;
            double actualEmployeeOne = Math.Round(_records[0].Tax, 2);

            double expectedEmployeeTwo = 133.76;
            double actualEmployeeTwo = Math.Round(_records[1].Tax, 2);

            double expectedEmployeeThree = 754.91;
            double actualEmployeeThree = Math.Round(_records[2].Tax, 2);

            double expectedEmployeeFour = 165.60;
            double actualEmployeeFour = Math.Round(_records[3].Tax, 2);

            double expectedEmployeeFive = 597.14;
            double actualEmployeeFive = Math.Round(_records[4].Tax, 2);

            Assert.AreEqual(expectedEmployeeOne, actualEmployeeOne);
            Assert.AreEqual(expectedEmployeeTwo, actualEmployeeTwo);
            Assert.AreEqual(expectedEmployeeThree, actualEmployeeThree);
            Assert.AreEqual(expectedEmployeeFour, actualEmployeeFour);
            Assert.AreEqual(expectedEmployeeFive, actualEmployeeFive);
        }

        [Test]
        public void TestNet()
        {
            double expectedEmployeeOne = 469.55;
            double actualEmployeeOne = Math.Round(_records[0].Net, 2);

            double expectedEmployeeTwo = 284.24;
            double actualEmployeeTwo = Math.Round(_records[1].Net, 2);

            double expectedEmployeeThree = 1447.09;
            double actualEmployeeThree = Math.Round(_records[2].Net, 2);

            double expectedEmployeeFour = 938.40;
            double actualEmployeeFour = Math.Round(_records[3].Net, 2);

            double expectedEmployeeFive = 1200.31;
            double actualEmployeeFive = Math.Round(_records[4].Net, 2);

            Assert.AreEqual(expectedEmployeeOne, actualEmployeeOne);
            Assert.AreEqual(expectedEmployeeTwo, actualEmployeeTwo);
            Assert.AreEqual(expectedEmployeeThree, actualEmployeeThree);
            Assert.AreEqual(expectedEmployeeFour, actualEmployeeFour);
            Assert.AreEqual(expectedEmployeeFive, actualEmployeeFive);
        }

        [Test]
        public void TestExport()
        {
            string fileName = @"Export\637373302845665428-records.csv";

            FileAssert.Exists(fileName); 
        }

    }
}