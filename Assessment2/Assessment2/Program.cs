using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Inputting some basic palindromes to be passed to the required function
            string s1 = "racecar";
            string s2 = "hannah";
            //Test case to make sure it does not always say palindrome
            string s3 = "apple";

            //initializing the bool variable for the return
            bool result;
            
            //calling palindromeCheck method then displaying the result to console for s1
            result = palindromeCheck(s1);
            Console.WriteLine(result);

            //calling palindromeCheck method then displaying the result to console for s2
            result = palindromeCheck(s2);
            Console.WriteLine(result);

            //calling palindromeCheck method then displaying the result to console for s3
            result = palindromeCheck(s3);
            Console.WriteLine(result);
            Console.ReadKey();
        }//end main


        //palindromeCheck method that accepts a string a returns a bool
        //checks to see if the strings are the same forwards as they are backwards
        static bool palindromeCheck(string input){
            
            //initializing the return variable
            //false until proven true
            bool palindrome = false;

            //new string to build a reverse of the original string
            string reverse = "";

            //looping through the input backwards to create a reversed string
            for (int i = input.Length - 1; i >= 0; i--){
                reverse += input[i];
            }

            //if the palidrome check is proven to be true then bool is switched to true
            //otherwise it is not a palindrome until proven true so return false
            if (input == reverse){
                palindrome = true;
            }
            //return bool
            return palindrome;
        }//end method
    }//end class
}//end namespace
