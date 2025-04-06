using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallengeOldPhonePad
{
    internal class Program
    {
        // main function with test cases
        static void Main(string[] args)
        {
            Console.WriteLine(OldPhonePad("33#"));  // Output should be "E"
            Console.WriteLine(OldPhonePad("227*#"));  // Output should be "B"
            Console.WriteLine(OldPhonePad("4433555 555666#"));  // Output should be "HELLO"
            Console.WriteLine(OldPhonePad("8 88777444666*664#"));  // Output should be ?????
        }

        public static string OldPhonePad(string input)
        {
            string msg = ""; //variable to store the message 
            string currValue = ""; //store current value in the loop 

            //use Dictionary to store phone keypad 
            Dictionary<string, string> keypad = new Dictionary<string, string>();
            keypad.Add("2", "abc");
            keypad.Add("3", "def");
            keypad.Add("4", "ghi");
            keypad.Add("5", "jkl");
            keypad.Add("6", "mno");
            keypad.Add("7", "pqrs");
            keypad.Add("8", "tuv");
            keypad.Add("9", "wxyz");

            for (int i = 0; i < input.Length; i++) //iterates the input given
            {
                char key = input[i]; //get one character

                if (key == ' ') // if there is a pause
                {
                    if (currValue.Length > 0)
                    {
                        int timesPressed = currValue.Length; //check how many times a key has been pressed
                        string value = currValue[0].ToString(); // to conver character to string
                        msg += keypad[value][(timesPressed - 1) % keypad[value].Length]; // get value of key from dictionary
                        currValue = ""; // clear current value
                    }
                    continue; //skips iteration
                }

                if (key == '*') // tp de;ete
                {
                    // Process any pending key press before deleting
                    if (currValue.Length > 0 && currValue[0] != '*')
                    {
                        int timesPressed = currValue.Length;
                        string value = currValue[0].ToString();
                        msg += keypad[value][(timesPressed - 1) % keypad[value].Length];
                        currValue = "";
                    }

                    if (msg.Length > 0) 
                    {
                        msg = msg.Remove(msg.Length - 1); //delete last value of output
                    }
                    continue;
                }

                if (key == '#') // break to finish
                {
                    if (currValue.Length > 0)
                    {
                        int timesPressed = currValue.Length;
                        string value = currValue[0].ToString();
                        msg += keypad[value][(timesPressed - 1) % keypad[value].Length];
                        currValue = "";
                    }
                    break;
                }

                if (currValue.Length > 0 && currValue[0] != key) //check if there is a value and is current key is different to last key
                {
                    int timesPressed = currValue.Length;
                    string value = currValue[0].ToString();
                    msg += keypad[value][(timesPressed - 1) % keypad[value].Length];
                    currValue = ""; 
                }

                currValue += key;
            }
            return msg.ToUpper(); // to return result with upper letter
        }

    }
}

