using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment0
{
    class Program
    {
        static void Main(string[] args)
        {
            //initializing variables that will be needed throughout the main
            int n = 0;
            //not adding data to array yet b/c the size has not been determined
            int[] ary;

            //allowing the ability for an array to be passed through as args, but not mandatory
            if (args.Length > 0){
                
                //determining length of array from args
                n = args.Length;

                //creating new memory for the array based on the size
                ary = new int[n];
                
                //copying array elements from string[] args to int[] ary
                for (int i = 0; i < ary.Length; i++){
                    ary[i] =  int.Parse(args[i]);
                }
            
            //if the values were not passed through using args then the user will be prompted to enter a string of 1's and 0's
            }else{
                
                //bool to control if the user inputs valid data (only 1's or 0's)
                bool validated = false;

                //accepting user input (asking for only 1's and 0's)
                string input = Prompt("Please input a string of 1's and 0's");

                //anticipating the user not wanting to follow directions *cough cough*
                //input validation
                while (!validated){
                    //setting valid to true to allow for the while loop to break when the string only has 1's and 0's
                    validated = true;

                    //looping through input string checking each char element
                    for (int i = 0; i < input.Length; i++){
                        //if the char is not a '1' and it is also not a '0' then set validated to false
                        if (input[i] != '0' && input[i] != '1'){
                            validated = false;
                        }
                    }
                    //if there are invalid values re-prompt the user to enter valid data
                    if (!validated){
                        input = Prompt("Invalid input, only use 1's and 0's");
                    }
                }//end validation loop

                //setting the length of the array to n
                n = input.Length;

                //creating new memory for ary with size n
                ary = new int[n];

                //copying values from validated input string to ary
                for (int i = 0; i < ary.Length; i++){
                    ary[i] =  int.Parse(input[i].ToString());
                }
            }

            //Writing the original unsorted array to screen one element at a time
            for (int i = 0; i < ary.Length; i++){
                Console.Write(ary[i]);
            }

            //calling bubbleSort method to sort ary from lowest to highest
            bubbleSort(ary);

            //formatting
            Console.Write(" => ");

            //writing the sorted array to the screen one element at a time
            for (int i = 0; i < ary.Length; i++){
                Console.Write(ary[i]);
            }
            Console.ReadKey();
        }//end main

        //prompt function that accepts a string a returns a user input string
        static string Prompt(string msg){
            Console.Write(msg + ": ");
            return Console.ReadLine();
        }//end method

        //function that takes an int array and two positions in that array to swap
        static void swap(int[] array, int pos1, int pos2){
            //creating temp variable to store one value while swapping the two values
            int temp = array[pos1];
            //swapping the values in position one and position two of the int array holding initial value of position one in the temp variable
            array[pos1] = array [pos2];
            array[pos2] = temp;
            
        }//end function


        //function that bubble sorts any array using the swap function
        static void bubbleSort(int[] array){
            //creating a bool to check if the array has been successfully sorted
            bool sorted = false;
            //while loop to go through array as many times as the array is manipulated
            while (!sorted){
                //setting sorted to true to be able to break out of the loop once the array has been sorted
                sorted = true;
                //looping through the array checking if on value is less than the value before
                for (int i = 1; i < array.Length; i++){
                    //if the value in the array at index i is less than the value in the array at index i-1 then,
                    if (array[i] < array [i-1]){
                        //swap function is called to swap the lesser value to before the greater value in the array index
                        swap(array, i, i-1);
                        //setting sorted to false because the program found an error and needs to run through the array until it is in order
                        sorted = false;
                    }
                }
            }
        }//end function
    }//end class
}//end namespace
