using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBSM
{
    public class Office : IEnumerable<Office>
    {
        public string Name; // id to identify each office 
        public Office Parent; // to keep track of the office to which this office reporst to
        public int Amount = 0;
        int Total = 0;
        private readonly Dictionary<string, Office> Childern = new Dictionary<string, Office>(); //all offices that report to this office



        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="amount"></param>
        public Office(string name)
        {
            this.Name = name;
        }
        public Office()
        {

        }

        public void SetAmount(int amount)
        {
            this.Amount = amount;

        }
        /// <summary>
        /// returns a office that descends from it
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Office GetDescendant(string name)
        {
            return this.Childern[name];
        }

        /// <summary>
        /// Adds a new descendant to the current office e.g SA office to HeadOffice
        /// </summary>
        /// <param name="NewOffice"></param>
        public void Add(Office NewOffice)
        {
            NewOffice.Parent = this;
            this.Childern.Add(NewOffice.Name, NewOffice);

        }

        /// <summary>
        /// Calculates the Net Profit of an Office by adding up the profits of all descending offices
        /// </summary>
        /// <returns></returns>
        public int NetProfit()
        {
            Total = Amount;
            if (this.Childern.Count() == 0)
            {
                return Total;             //stop case. Net Profit is the Amount unless the office has descendants
            }

            foreach (var office in Childern)
            {
                Total += office.Value.NetProfit();
            }
            return Total;
        }


        public IEnumerator<Office> GetEnumerator()
        {
            IEnumerator<Office> IEnum = this.Childern.Values.GetEnumerator();
            return IEnum;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

}
