using System;
using System.Collections.Generic;

namespace Neal_StringYouAlong
{
    class StringManager
    {
        private string _currentString;
        private Dictionary<int, string> _valuePairs = new();

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
            set { _valuePairs = value; }
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
            if (s == Reverse(s))
                return true;
            else
                return false;
        }
        public override string ToString()
        {
            Queue<int> ASCII = new();
            for (int i = 0; i < CurrentString.Length; i++)
            {
                if ((int)CurrentString[i] == 32 ||
                    ((int)CurrentString[i] > 64 && (int)CurrentString[i] < 91) ||
                    ((int)CurrentString[i] > 96 && (int)CurrentString[i] < 123))
                    ASCII.Enqueue((int)CurrentString[i]);
            }
            if (ASCII.Count < 1)
            {
                return ValuePairs[-1];
            }
            else
            {
                string output = null;
                int qLength = ASCII.Count;
                int sumOfASCII = 0;

                for (int i = 0; i < qLength; i++)
                {
                    sumOfASCII += ASCII.Dequeue();
                }

                int[] sumArray = GetDigits(sumOfASCII);

                for (int i = 0; i < sumArray.Length; i++)
                {
                    if (i == 0)
                    {
                        output = ValuePairs[sumArray[i]];
                    }
                    else
                    {
                        output += " " + ValuePairs[sumArray[i]];
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
            ValuePairs.Add(0, "Zero");
            ValuePairs.Add(1, "One");
            ValuePairs.Add(2, "Two");
            ValuePairs.Add(3, "Three");
            ValuePairs.Add(4, "Four");
            ValuePairs.Add(5, "Five");
            ValuePairs.Add(6, "Six");
            ValuePairs.Add(7, "Seven");
            ValuePairs.Add(8, "Eight");
            ValuePairs.Add(9, "Nine");
        }

        private static int[] GetDigits(int number)
        {
            int length = (int)Math.Ceiling(Math.Log10(number));

            int[] intArray = new int[length];

            int power = (int)Math.Pow(10, length - 1);

            for (int i = length - 1; i >= 0; --i)
            {
                intArray[length - i - 1] = number / power;
                number -= intArray[length - i - 1] * power;
                power /= 10;
            }

            return intArray;
        }
    }
}
