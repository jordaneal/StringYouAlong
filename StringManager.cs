using System;
using System.Collections.Generic;

namespace Neal_StringYouAlong
{
    class StringManager
    {
        private string _currentString;
        private readonly Dictionary<int, string> _valuePairs = new();

        public StringManager()
        {
            SetValuePairs();
        }
        private string CurrentString
        {
            get { return _currentString; }
            set { _currentString = value; }
        }
        private Dictionary<int, string> ValuePairs
        {
            get { return _valuePairs; }
        }
        public string Reverse(string s)
        {
            CurrentString = s;
            Stack<char> charStack = new();
            string temp = null;

            for (int i = 0; i < CurrentString.Length; i++)
            {
                charStack.Push(CurrentString[i]);
            }
            for (int i = 0; i < CurrentString.Length; i++)
            {
                temp += charStack.Pop();
            }
            return temp;
        }
        public string Reverse(string s, bool b)
        {
            if (!b)
            {
                return Reverse(s);
            }

            CurrentString = s;
            Stack<char> charStack = new();
            string temp = null;
            bool[] casing = new bool[CurrentString.Length];

            for (int i = 0; i < CurrentString.Length; i++)
            {
                charStack.Push(CurrentString[i]);

                if (((int)CurrentString[i] > 64 && (int)CurrentString[i] < 91) ||
                    ((int)CurrentString[i] > 96 && (int)CurrentString[i] < 123) &&
                    CurrentString[i].ToString() == CurrentString[i].ToString().ToUpper())
                {
                    casing[i] = true;
                }
            }
            for (int i = 0; i < CurrentString.Length; i++)
            {
                if (casing[i])
                {
                    temp += charStack.Pop().ToString().ToUpper();
                }
                else
                {
                    temp += charStack.Pop().ToString().ToLower();
                }
            }
            return temp;
        }
        public bool Symmetric(string s)
        {
            CurrentString = s;
            if (s == Reverse(s))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override string ToString()
        {
            int ASCII = 0;
            for (int i = 0; i < CurrentString.Length; i++)
            {
                if ((int)CurrentString[i] == 32 ||
                    ((int)CurrentString[i] > 64 && (int)CurrentString[i] < 91) ||
                    ((int)CurrentString[i] > 96 && (int)CurrentString[i] < 123))
                    ASCII += (int)CurrentString[i];
            }
            if (ASCII < 32)
            {
                return ValuePairs[-1];
            }
            else
            {
                string sumOfASCII = ASCII.ToString();
                string output = string.Empty;
                //int[] sumArray = GetDigits(ASCII);

                for (int i = 0; i < sumOfASCII.Length; i++)
                {
                    if (i == 0)
                    {
                        output = ValuePairs[sumOfASCII[i]];
                    }
                    else
                    {
                        output += " " + ValuePairs[sumOfASCII[i]];
                    }
                }
                return output;
            }
        }
        public override bool Equals(object obj)
        {
            return obj is string s && CurrentString == s;
        }
        private void SetValuePairs()
        {
            ValuePairs.Add(-1, "Negative One");
            ValuePairs.Add(48, "Zero");
            ValuePairs.Add(49, "One");
            ValuePairs.Add(50, "Two");
            ValuePairs.Add(51, "Three");
            ValuePairs.Add(52, "Four");
            ValuePairs.Add(53, "Five");
            ValuePairs.Add(54, "Six");
            ValuePairs.Add(55, "Seven");
            ValuePairs.Add(56, "Eight");
            ValuePairs.Add(57, "Nine");
        }
        //private static int[] GetDigits(int number)
        //{
        //    int length = (int)Math.Ceiling(Math.Log10(number));
        //    int[] intArray = new int[length];
        //    int power = (int)Math.Pow(10, length - 1);

        //    for (int i = length - 1; i >= 0; --i)
        //    {
        //        intArray[length - i - 1] = number / power;
        //        number -= intArray[length - i - 1] * power;
        //        power /= 10;
        //    }
        //    return intArray;
        //}
    }
}
