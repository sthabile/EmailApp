using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using GBSM;

namespace GBSMQ2
{
    class Program
    {
        static void Main(string[] args)
        {

            try //use trycatch in case the file isn't found 
            {
                //read the excel file line by line into a string array 
                Console.WriteLine("Enter input File Name");
                string[] input = File.ReadAllLines(Console.ReadLine());
                Dictionary<string, Office> AllOffices = new Dictionary<string, Office>(); //Possible parents

                #region //use the OFFICE class to sort and store the data
                for (int line = 1; line < input.Length; line++) //read each line from the given file
                {
                    string[] temp = input[line].Split(',');    // split at commas 
                    /*create currOffice using first item in temp
                      *use the first item to see if parent office is null.
                      *create an office using the second item and set curr.parent to it
                     */
                    Office currOffice = new Office(temp[0]);
                    currOffice.SetAmount(Convert.ToInt32(temp[2]));
                    if (currOffice.Name != "HeadOffice")
                    {

                        Office ParentOffice;
                        if (AllOffices.TryGetValue(temp[1], out ParentOffice))
                        {
                            ParentOffice.Add(currOffice);
                        }
                    }
                    AllOffices.Add(currOffice.Name, currOffice);  //Add to list of all offices

                }
                #endregion

                #region//Find the office with the largest Net Profit
                int LargerProfit = 0;  //Variable to assign Largest profit to
                string OfficeWithLargestProfit = "";  //variable for office name for office with largest profit
                foreach (var office in AllOffices)
                {
                    Office currOffice = office.Value;
                    if (LargerProfit == 0)      //assign the first NetProfit to compare against other offices
                    {
                        LargerProfit = currOffice.NetProfit();
                        OfficeWithLargestProfit = currOffice.Name;
                    }
                    else if(LargerProfit<= currOffice.NetProfit())  //if the following office has a net profit greater than the netprofit already recored,
                    {
                        LargerProfit = currOffice.NetProfit();      //set LargerProfit to that Office's net profit
                        OfficeWithLargestProfit = currOffice.Name;  //record its Name
                    }
                   
                }

                Console.WriteLine("The office with the largest Net Profit is : " + OfficeWithLargestProfit + " at " + LargerProfit + " per year");
                Console.ReadKey();
                #endregion


            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Could not find file");
                Console.ReadLine();
            }
        }
    }
}
