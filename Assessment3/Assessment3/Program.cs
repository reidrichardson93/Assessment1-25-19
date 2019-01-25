using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assessment3
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //initializing input string to be used throughout the main
            string input = "";

            //option to pass the file path through args
            if (args.Length > 0){
                if (args[0].EndsWith(".txt")){
                    input = args[0];
                
                //validating file path and repropmting if invalid
                }else{
                    while(!input.EndsWith(".txt")){
                        input = Prompt("Please enter a valid '.txt' file path that includes the file extension");
                    }
                }

            //otherwise prompt user for file path
            }else{
                input = Prompt("Please enter a '.txt' file path to read from\nPlease include the '.txt' file extension");

                //validating file path
                while(!input.EndsWith(".txt")){
                    input = Prompt("Please enter a valid '.txt' file path that includes the file extension");
                }
            }
            //reading file and storing all text in string file
            string file = File.ReadAllText(input);

            //creating a split_on char[] to get rid of punctuation and such
            char[] split_on = {' ', ',', '.', '\n', '!', '?', '@', '#', '$', '%', '^', '&', '*', '(', ')', '<', '>', '\'', '"', '\t', '\\', '+', '=', '|', '}', '{', '[', ']', ';', ':', '/', '`', '~', '-', '_'};

            //splitting words in the file to string[] words without punctuation
            string[] words = file.Split(split_on, StringSplitOptions.RemoveEmptyEntries);

            //method called to find the index of the word with the max length
            int max_index = find_max_length_index(words);
            //getting max length value
            int max_length = words[max_index].Length + 2;

            //drawing the top bar of '*'
            for (int i = 0; i < max_length + 2; i++){
                Console.Write("*");
            }
            //\n
            Console.WriteLine();
            //looping through the words printing the formatted text box
            for(int i = 0; i < words.Length; i++){

                if (words[i].Length < max_length){
                    int diff = max_length - words[i].Length;
                    Console.Write("* " + words[i]);
                    //padding the back of the words with spaces
                    //on second thought I could probably have used padRight(), but too late
                    for(int j = 0; j < diff - 1; j++){
                        Console.Write(" ");
                    }
                    Console.WriteLine("*");
                }else{
                    Console.WriteLine("* " + words[i] + "*");
                }
            }
            //printing bottom bar of text box
            for (int i = 0; i < max_length + 2; i++){
                Console.Write("*");
            }

            Console.ReadKey();
        }//end main

        //prompt function that accepts a string a returns a user input string
        static string Prompt(string msg){
            Console.Write(msg + ": ");
            return Console.ReadLine();
        }//end method

        //method that finds the index for the longest value in the string array
        //accepts a string array and returns the index as an int
        static int find_max_length_index(string[] ary){
            //initializing return int
            int index = 0;
            //setting the first element in array to the longest element and storing the length
            int max_length = ary[0].Length;

            //looping through the rest of the elements checking if they are longer than the current longest element
            for (int i = 1; i < ary.Length; i++){
                //if the current element is longer than the longest element then the current element is set to the longest
                if (ary[i].Length > max_length){
                    max_length = ary[i].Length;
                    index = i;
                }
            }
            //return index of longest element
            return index;
        }//end method

    }//end class
}//end namespace
