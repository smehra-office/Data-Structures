using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Structures
{
    class StringOperations
    {

        private IDictionary<char, char> CharacterMap;

        public StringOperations()
        {
            CharacterMap = new Dictionary<char, char>
            {
                { '}','{' },
                {']','[' },
                { '>','<'},
                { ')','('}
            };
        }

        public void ReverseString(string str)
        {
            Stack<char> stack = new Stack<char>();
            foreach (char item in str)
                stack.Push(item);

            StringBuilder reversedString = new StringBuilder();

            while (stack.Count > 0)
            {
                reversedString.Append(stack.Pop());
            }

            Console.WriteLine(reversedString);
        }

        public bool CheckBalancedExpression(string str)
        {
            if (str.Length == 0)
                return false;

            Stack<char> stack = new Stack<char>();
            foreach (char s in str)
            {
                switch (s)
                {
                    case '[':
                    case '{':
                    case '<':
                    case '(':
                        {
                            stack.Push(s);
                            break;
                        }
                    case ')':
                    case '>':
                    case '}':
                    case ']':
                        {
                            if (stack.Count > 0 && stack.Peek() == CharacterMap[s])
                                stack.Pop();
                            else
                                return false;
                            break;
                        }
                }
            }
            return stack.Count == 0;
        }
    }
}

