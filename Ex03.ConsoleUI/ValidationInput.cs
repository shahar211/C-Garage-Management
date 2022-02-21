namespace Ex03.ConsoleUI
{
    using System;
    using System.Text;

    internal class ValidationInput
    {
        public static float CheckIfUserFloatNumberInRange(float i_MaxRange)
        {
            float floatToCheck = 0;
            bool found = false;
            
            while (!found)
            {
                floatToCheck = GetVariable<float>();
                found = checkInNumberRange(floatToCheck, i_MaxRange);
            }

            return floatToCheck;
        }

        public static int CheckIfUserIntNumberInRange(int i_MaxRange)
        {
            int intToCheck = 0;
            bool found = false;

            while (!found)
            {
                intToCheck = GetVariable<int>();
                found = checkInNumberRange(intToCheck, i_MaxRange);
            }

            return intToCheck;
        }

        private static bool checkInNumberRange(float i_NumberToCheck, float i_MaxRange)
        {
            bool found = false;

            if (i_NumberToCheck <= i_MaxRange && i_NumberToCheck >= 0)
            {
                found = true;
            }
            else
            {
                string message = string.Format(@"Error! The Number not in range between 0-{0}", i_MaxRange);

                Console.WriteLine(message);
            }

            return found;
        }

        public static T GetVariable<T>()
        {
            bool isValid = false;
            T userInput = default(T);

            while (isValid == false)
            {
                try
                {
                    userInput = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));
                    isValid = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error! Wrong Input Type");
                }
            }

            return userInput;
        }

        public static string CheckStringInputLength()
        {
            string userInput = Console.ReadLine();

            while(!(userInput.Length != 0))
            {
                Console.WriteLine("Error! Enter Another Input");
                userInput = Console.ReadLine();
            }

            return userInput;
        }
    }
}