using System;

// Jordan Neal
// IT113
// NOTES: Hardest part was the "GetDigits" method used in SM class.
//        Was ubale to take the ASCII sum value and use .ToString()
//        and then convert to an Int[], so I got creative... I'm sure
//        there was an easier way.
//        UPDATE: IDK why ToString() wasn't working, but it does now.
//                Leaving in my hard worked code in comments...
// BEHAVIORS NOT IMPLIMENTED AND WHY: 

namespace Neal_StringYouAlong
{
    class Program
    {
        static void Main()
        {
            StringManager sm = new();

            Console.WriteLine($"Sunbeam Tiger reversed: { sm.Reverse("Sunbeam Tiger")}" +
                $"\nSunbeam Tiger ToString() ASCII value: {sm}" +
                $"\nSunbeam Tiger reversed w/ preserved casing location: {sm.Reverse("Sunbeam Tiger", true)}" +
                $"\nEquality Check: {sm.Equals("Sunbeam Tiger")}" +
                $"\nSymmetric check for ABBA: {sm.Symmetric("ABBA")}" +
                $"\nSymmetric check for ABA: {sm.Symmetric("ABA")}" +
                $"\nSymmetric check for ABba: {sm.Symmetric("ABba")}");
        }

        // Reverse a string "Sunbeam Tiger"
        // Call ToString to output the string equivalent of all ASCII summed values "One Two Five Three"
        // Reverse a string "Sunbeam Tiger" preserving casing location in the string
        // Equality Check call for "Sunbeam Tiger"
        // Symmetric check for "ABBA"
        // Symmetric check for "ABA"
        // Symmetric check for "ABba"
    }
}