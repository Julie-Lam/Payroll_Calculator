using System;
using System.Collections.Generic;
using System.Text;

namespace MyPayProject
{
    class ResidentPayRecord : PayRecord
    {
        //Gross & Net are inherited properties 
        //Tax is a unique property. 
        public override double Tax
        {
            get { return TaxCalculator.CalculateResidentialTax(Gross); }
        }
        /// <summary>
        /// Constructor - assigns the id, _hours and _rates fields 
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="_hours"></param>
        /// <param name="_rates"></param>
        public ResidentPayRecord(int Id, double[] _hours, double[] _rates) :base(Id, _hours, _rates)
        {
            this.id = Id;
            this._hours = _hours;
            this._rates = _rates; 
        }

        /// <summary>
        /// Returns a message with Employee id, and gross, net and tax amount.  
        /// </summary>
        /// <returns></returns>
        public override string GetDetails()
        {
            return "----- EMPLOYEE: " + id + " -----" +
            "\nGross: $" + Gross + "\nNet: $" + Net + "\nTax: $" + Tax; 
        }
    }
}
