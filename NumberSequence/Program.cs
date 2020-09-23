using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberSequence
{
    class Program
    {
        static int Command1(int n, int k, string[] numbers)
        {
            int partialSum = 0, count = 0;
            int[] modArray = new int[k]; //array where the frequency of the rests of the partial sums modulo k will be stored

            for (int i = 0; i < n; i++)
            {
                int x = int.Parse(numbers[i]); //take the i-th number from stdin
                partialSum += x; //add to the partial sum 
                modArray[(partialSum % k + k)%k]++; //the element representing the rest obtained increments by 1. If the number is negative, we obtain the corresponding positive rest
            }

            for (int i = 0; i < k; i++)
            {
                if (modArray[i] > 1) //if there are at least 2 partial sums with the same rest modulo k 
                {
                    count += (modArray[i] * (modArray[i] - 1)) / 2; //the number of subsequences up is combinations of frequency taken 2 for each rest
                }
            }
            count += modArray[0]; //we add the numbers that are dividing exactly by k
            return count; 
        }

        static int Command2(int n, string[] numbers)
        {
            int parity, x, count = 0, length = 1;
            x = int.Parse(numbers[0]); //take the first integer
            parity = x % 2; //calculate its parity
            for(int i=1; i<n;i++)
            {
                x = int.Parse(numbers[i]); //get the next intger from stdin
                if (x % 2 != parity) //if the parity is different from the previous parity
                {
                    count = count + length * (length + 1) / 2; //we add too the counter the number of partitions of size = length
                    parity = x % 2; //change the parity to the new one
                    length = 1; //the length of the new sequence is 1 
                }
                else
                    length++; //the length of the sequence increments by 1
            }
            count = count + length * (length + 1) / 2; //we add to the counter the number of partitions of size = length of the last sequence of numbers, as it is not finished by parity change
            return count;
        }

        static void Main(string[] args)
        {
            int command = int.Parse(Console.ReadLine()); //read the operation performed

            string[] param = Console.ReadLine().Split(); //read the line with n and k
            int n = int.Parse(param[0]);
            int k = int.Parse(param[1]);

            string[] numbers = Console.ReadLine().Split(); //read the array of numbers 

            if (command==1)
            {
                Console.WriteLine(Command1(n, k, numbers)); //call the function calculating the first problem: count the total number of sequences of numbers diividing by k 
            }
            else if (command==2)
            {
                Console.WriteLine(Command2(n, numbers)); //call the function calculating the second problem: count the longest sequence of same parity numbers
            }

            Console.ReadLine();
        }
    }
}
