using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace GBSM
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


                #region  //read in input and display the Net Profit
                while (true)
                {
                    Console.Write("Question 1 \nEnter office to calculate Nett profit for:\n");
                    string currOfficeName = Console.ReadLine();
                    try
                    { 
                        //use the input string to index AllOffices and get the Net Profit.
                        Console.WriteLine(AllOffices[currOfficeName].NetProfit() + "\n");
                        Console.WriteLine("....Press Enter/C to exit/continue....\n");
                        if (string.IsNullOrEmpty(Console.ReadLine()))
                        {
                            break;
                        }
                        else { continue; }

                    }
                    catch
                    {
                        Console.WriteLine("Invalid Office name.\n");
                        continue;
                    }

                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Could not find file");
                Console.ReadLine();
            }


        }
            #endregion




        
    }
}
