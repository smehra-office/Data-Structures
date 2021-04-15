using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures
{
    class CharFinder
    {

        private int Integer = -1;
        private int Frequency = -1;

        public string FindFirstNonRepeatChar(string element)
        {
            if (isEmptyString(element))
                return element;

            IDictionary<char, bool> dict = new Dictionary<char, bool>();

            foreach (char c in element)
                dict[c] = dict.ContainsKey(c) ? false : true;

            char result = dict.FirstOrDefault(e => e.Value.Equals(true)).Key;

            return result.ToString();
        }

        public string FindFirstRepeatingChar(string element)
        {
            if (isEmptyString(element))
                return element;

            ISet<char> set = new HashSet<char>();
            foreach (char c in element)
                /* Returns FALSE if key already exists else returns TRUE */
                if (!set.Add(c))
                    return c.ToString();

            return null;
        }

        public int MostRepeatedInteger(int[] array)
        {
            if (array != null || array.Length > 0)
            {
                IDictionary<int, int> counter = new Dictionary<int, int>();

                foreach (int number in array)
                {
                    int value = counter.ContainsKey(number) ? counter[number] + 1 : 1;
                    counter[number] = value;
                    updateMaxNumber(number, value);
                }
            }
            return Integer;
        }

        public int[] TwoSum(int[] array, int target)
        {
            if (!checkInvalidInput(target, array))
            {
                ISet<int> set = new HashSet<int>();

                /* Add to set */
                foreach (int element in array)
                    set.Add(element);

                foreach (int element in set)
                {
                    int secondNumber = Math.Abs(target - element);
                    if (set.Contains(secondNumber))
                        return new int[] { element, secondNumber };
                }
            }

            return null;
        }

        private bool checkInvalidInput(int target, int[] array)
        {
            return target < 1 || array == null || array.Length == 0;
        }

        private void updateMaxNumber(int number, int frequency)
        {
            if (frequency > Frequency)
            {
                Integer = number;
                Frequency = frequency;
            }
        }

        private bool isEmptyString(string element)
        {
            return element == null || element.Length == 0;
        }
    }
}
