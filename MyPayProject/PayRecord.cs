using System;
using System.Collections.Generic;
using System.Text;

namespace MyPayProject
{
    public abstract class PayRecord
    {
        //fields
        protected double[] _hours;
        protected double[] _rates;
        protected int id; 

        //properties
        public int Id {
            get { return id; } // public getter 
            private set { id = value; } // private setter 
        } 

        public double Gross {
            get {
                //loop through the parallel arrays and find the result from each array[i]. Add up the sum of each array[i] result.
                double gross = 0; 
                for (int i = 0; i < _hours.Length; i++) {
                    gross += _hours[i] * _rates[i];
                }; 

                return gross; 
            } //public getter, no setter
        }

        public abstract double Tax {
            get; //public abstract getter, no setter. || Tax is uniquely calculated for ea. child class. 
        }
        public double Net
        {
            get {
                return Gross - Tax; 
            } //public getter, no setter
        }

        /// <summary>
        /// Generates the constructor for the PayRecord class, assigns the id, _hours and _rates fields.  
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hours"></param>
        /// <param name="rates"></param>
        public PayRecord(int id, double[] hours, double[] rates)
        {
            this.id = id;
            this._hours = hours;
            this._rates = rates; 
        }
        /// <summary>
        /// A default method to be overwritten by child classes, returns a message with employee Id, and the gross and tax amount. 
        /// </summary>
        /// <returns></returns>
        public virtual string GetDetails() {
            return $"ID: {id}, Gross: {Gross}, Tax: {Tax}";
        }

    }
}
