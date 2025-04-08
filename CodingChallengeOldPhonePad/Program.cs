using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallengeOldPhonePad
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(OldPhonePad("33#"));  // Output should be "E"
            Console.WriteLine(OldPhonePad("227*#"));  // Output should be "B"
            Console.WriteLine(OldPhonePad("4433555 555666#"));  // Output should be "HELLO"
            Console.WriteLine(OldPhonePad("8 88777444666*664#"));  // Output should be ?????
        }

        //this function get the key was press and retunr it with the message
        private static string GetPressedKey(string currValue, Dictionary<string, string> keypad, string msg)
        {
            int timesPressed = currValue.Length; //check how many times a key has been pressed
            string value = currValue[0].ToString(); //convert character to string
            return msg += keypad[value][(timesPressed - 1) % keypad[value].Length]; //get character, appent it to message and return it
        }

        public static string OldPhonePad(string input)
        {
            string msg = ""; //variable to store the message 
            string currValue = ""; //variable to store current value press

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

            for (int i = 0; i < input.Length; i++) //iterates over the input of function
            {
                char key = input[i]; //get one character

                if (key == ' ') // if there is a pause
                {
                    if (currValue.Length > 0)
                    {                      
                        msg = GetPressedKey(currValue, keypad, msg);
                        currValue = ""; // clear current value
                    }
                    continue; //skips iteration
                }

                if (key == '*') // tp de;ete
                {
                    // Process any pending key press before deleting
                    if (currValue.Length > 0 && currValue[0] != '*')
                    {
                        msg = GetPressedKey(currValue, keypad, msg);
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
                        msg = GetPressedKey(currValue, keypad, msg);
                        currValue = "";
                    }
                    break;
                }

                if (currValue.Length > 0 && currValue[0] != key) //check if there is a value and is current key is different to last key
                {
                    msg = GetPressedKey(currValue, keypad, msg);
                    currValue = ""; 
                }

                currValue += key;
            }
            return msg.ToUpper(); // to return result with upper letter
        }

    }
}

