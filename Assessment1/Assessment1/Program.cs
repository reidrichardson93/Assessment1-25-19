using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assessment1
{
    class Program
    {
        static void Main(string[] args)
        {
            //initializing input string to be used thoughout the main
            string input = "";

            //optional method of passing file path through args
            if (args.Length > 0){
                
                //making sure the file enterd is a .cs file
                if (args[0].EndsWith(".cs")){

                    //copying path to input
                    input = args[0];

                //if file entered is not a .cs file then reprompt user
                }else{
                    //while validation loop to keep prompting until a .cs file is supplied
                    while(!input.EndsWith(".cs")){
                        input = Prompt("Please enter a valid '.cs' file path that includes the file extension");
                    }
                }

            //if the path was not passed through args then go straight to prompting user for path
            }else{
                
                //prompting user for .cs path including extension
                input = Prompt("Please enter a '.cs' file path to read from\nPlease include the '.cs' file extension");

                //validation loop to make sure path entered is a .cs file
                while(!input.EndsWith(".cs")){
                    input = Prompt("Please enter a valid '.cs' file path that includes the file extension");
                }
            }

            //initializing stream reader object to loop through the .cs file that was supplied
            StreamReader read_file = new StreamReader(input);

            //initializing a couple of control bools telling the program which lines to copy and which not to
            bool multiLine = false;
            bool add = false;

            //while streamreader is not at the end of the file
            while(!read_file.EndOfStream){
                //resetting add to false if the reader is not on a multiline comment
                if (!multiLine){
                    add = false;
                }

                //string that stores the comments one line at a time then prints to screen and resets for the next line
                string comments = "";

                //reading through the file one line at a time
                string current_line = read_file.ReadLine();

                //for loops that goes through the current line of the .cs file looking for comment keywords ('//' and '/*' % '*/')
                for(int i = 0; i < current_line.Length; i++){
                    
                    //this allows the next statements to not go outside of bounds while still making the for loop check the entire line of code
                    if (i != current_line.Length - 1){
                        //if a comment keyword is found then switch the add (add line) bool to true in order to print the line to the screen
                        if(current_line[i] == '/' && current_line[i + 1] == '/'){
                            //bool switched to true
                            add = true;
                        }
                        //if a multiline comment keyword is found then switch the add and the multiline bool to true
                        if (add == false && current_line[i] == '/' && current_line[i + 1] == '*'){
                            add = true;
                            multiLine = true;
                        }
                        //when a multiline comment is found then add and multiline will stay true until the end multiline comment
                        //keyword is found, when found both add and multiline as switched off
                        if (add == true && current_line[i] == '*' && current_line[i + 1] == '/'){
                            add = false;
                            multiLine = false;
                            //adds a end multiline comment keyword to the string b/c it is left off otherwise
                            comments += "*/";
                            
                        }
                    }
                    //if add is true then the comments string is built one char at a time until a single line comment line ends or the
                    //end multiline comment keyword is found
                    //doing this one char at a time allows for inline comments(multiline comments used within code body) to be extracted
                    if (add) {
                        //building the comments one char at a time
                        comments += current_line[i].ToString();
                    }
                }
                //taking away the lines of code that are not stored in comments to get rid of white space btw comments
                if(comments != ""){
                    Console.WriteLine(comments);
                }
            }
            Console.ReadKey();
            
        }//end main
        
        //prompt function that accepts a string a returns a user input string
        static string Prompt(string msg){
            Console.Write(msg + ": ");
            return Console.ReadLine();
        }//end method


    }//end class
}//end namespace
