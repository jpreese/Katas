using System;
using System.Linq;

namespace StringKata
{
    public class StringCalculator
    {
        public int Add(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return 0;
            }

            var delimeters = ",\n";

            if (input.StartsWith("//"))
            {
                delimeters += input[2];
                input = input.Substring(4, input.Length - 4);
            }

            var numbers = input.Split(delimeters.ToCharArray()).Select(int.Parse).ToList();
            var negatives = numbers.Where(x => x < 0).ToList();

            if (negatives.Any())
            {
                throw new ArgumentException(string.Format("Invalid numbers: {0}", string.Join(",", negatives)));
            }

            return numbers.Sum();
        }
    }
}
