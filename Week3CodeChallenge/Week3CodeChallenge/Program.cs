using System;
using System.Collections.Generic;
using System.Linq;

namespace Week3CodeChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            FindNPrimes(6);
            Console.WriteLine(EvenFibonacciSequencer(8));
            long test = LongestCollatzSequence();

            Console.ReadKey();
        }
        /// <summary>
        /// A function that calculates the starting value of the longest Collatz sequence.
        /// This function will start at 1 million and look at which value generates the
        /// longest sequence.
        /// </summary>
        /// <returns>Starting value of the longest sequence</returns>
        public static long LongestCollatzSequence()
        {
            //declaring variable for holding a longest chain amount
            int longestChain = 0;
            //variable for holding the number of longest chain
            long holderForNumber = 0;
            //looping from 2 to 1 million
            for (long i = 2; i < 1000001; i++)
            {
                //declaring variable for current chain amount
                int currentCounter = 1;
                //saving original number before performing calculations on it 
                long numberBeforeCalculation = i;
                //going inside below loop if number is not 1
                while (i != 1)
                {
                    //checking if number is even and incrementing current counter
                    if (i % 2 == 0)
                    {
                        i = i / 2;
                        currentCounter++;
                    }
                    //if not even then it's odd.incrementing current counter as well
                    else{
                        i = 3 * i + 1;
                        currentCounter++;
                    }
                }
                //setting i back to its original value
                i = numberBeforeCalculation;
                //checking if current chain amount is bigger the last longest chain amount
                if (longestChain < currentCounter)
                {
                    //if it's bigger then setting its value as longest and saving the number
                    longestChain = currentCounter;
                    holderForNumber = numberBeforeCalculation;
                }
            }
            return holderForNumber; 
        }

        /// <summary>
        /// A Function that adds up each even number in a Fibonacci Sequence until the maxValue
        /// then prints the sum of those numbers to the console
        /// </summary>
        /// <param name="maxValue"></param>
        /// <returns>The sum of every even number for the given number of Fibonacci digits</returns>
        public static long EvenFibonacciSequencer(long maxValue)
        {
            //declaring variables for holding current two numbers
            int firstNumber = 1;
            int secondNumber = 2;
            //variable for holding a sum of two current numbers
            int sumOfFirstAndSecond = 0;
            //variable for holding sum of all even numbers
            long sumOfAllEven = 2;
            //looping until we reach the max value indicated in input
            while (sumOfFirstAndSecond < maxValue)
            {
                //adding two current numbers together
                sumOfFirstAndSecond = firstNumber + secondNumber;
                //checking if next number in seqence is even
                if (sumOfFirstAndSecond % 2 == 0)
                {
                    //if it's even then adding it into sum variable
                    sumOfAllEven += sumOfFirstAndSecond;
                }
                //changing numbers and continue Fibonacci sequence
                firstNumber = secondNumber;
                secondNumber = sumOfFirstAndSecond;
            }
            return sumOfAllEven; 
        }

        /// <summary>
        /// Function that finds the n'th prime indicated by the parameter
        /// </summary>
        /// <param name="maxPrime"></param>
        /// <returns>The prime number which is the n'th found</returns>
        public static int FindNPrimes(int maxPrime)
        {
            //declaring counter for prime numbers
            int counter = 0;
            //declaring the starting number to check
            int number = 2;
            //checking if we reached a necessary amount of primes as per input value
            while (counter != maxPrime)
            {
                //calling a function to check if number is prime
                if (IsPrime(number))
                {
                    //incrementing counter if number is prime
                    counter++;
                }
                //proceeding to next number to check
                number++;
            }
            //returning previous number because of extra incrementation in loop
            return number-1; 
        }
        /// <summary>
        /// A function that checks if number is prime
        /// </summary>
        /// <param name="number">Number to check</param>
        /// <returns>Returns true if number if prime and false if not</returns>
        public static bool IsPrime(int number)
        {
            //TESTS FOR SPEEDING UP THE ALGORITHM
            //if (number == 2 || number == 3)
            //{
            //    return true;
            //}
            //if (number % 2 == 0 || number % 3 == 0)
            //{
            //    return false;
            //}
            for (int i = 2; i * i <= number; i++ )
            {
              
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;

            //OLD AND SLOW ALGORITHM
            //if (number == 2)
            //{
            //    return true;
            //}
            //for (int i = 2; i < number; i++)
            //{
            //    if (number % i == 0)
            //    {
            //        return false;
            //    }
            //}
            //return true;

        }
    }
}
