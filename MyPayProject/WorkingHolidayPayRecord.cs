using System;
using System.Collections.Generic;
using System.Text;

namespace MyPayProject
{
    class WorkingHolidayPayRecord : PayRecord
    {
        //fields
        private int visa;
        private double yearToDate; 

        //properties - also inherited Id and Gross properties 
        public int Visa
        {
            get { return visa; } //public getter, private setter
            private set { visa = value; }
        }

        public double YearToDate
        {
            get {return yearToDate + Gross; } //public getter, private setter
            private set { yearToDate = value; }
        }

        public override double Tax
        {
            get { return TaxCalculator.CalculateWorkingHolidayTax(Gross, yearToDate); }
        }

        /// <summary>
        /// Constructor - assigns the id, _hours, _rates, visa and yearToDate fields
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hours"></param>
        /// <param name="rates"></param>
        /// <param name="visa"></param>
        /// <param name="yearToDate"></param>
        public WorkingHolidayPayRecord(int id, double[] hours, double[] rates, int visa, int yearToDate) : base(id, hours, rates)
        {
            this.id = id;
            this._hours = hours;
            this._rates = rates;
            this.visa = visa;
            this.yearToDate = yearToDate; 
        }

        /// <summary>
        /// Returns a message with Employee ID, gross, net and Tax amount, visa number and year to date amount. 
        /// </summary>
        /// <returns></returns>
        public override string GetDetails()
        {
            return "----- EMPLOYEE: " + id + " -----" +   
            "\nGross: $" + Gross + "\nNet: $" + Net + "\nTax: $" + Tax + "\nVisa: " + Visa + "\nYTD: $" + YearToDate; 
        }
    }
}
