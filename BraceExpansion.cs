using System;
using System.Collections.Generic;
using System.Text;

namespace BackTracking
{
    public class BraceExpansion
    {
        /*
         * T.C: O(k power n)  where k is avg length of block and n is no of chars in string
         * S.C: O(nK(logK) where n is no of chars and since we are sorting the each block before adding  k(LogK)
         */
        List<string> Result;
        public string[] expand(string s)
        {
            int n = s.Length;
            List<List<char>> Blocks = new List<List<char>>();
            Result = new List<string>();
            int i = 0;

            while(i < n )
            {
                List<char> block = new List<char>();
                if (s[i] == '{')
                {
                    i++;
                    while(s[i] != '}')
                    {
                        if (s[i] != ',')
                        {
                            block.Add(s[i]);
                        }
                        i++;
                    }
                }
                else
                {
                    block.Add(s[i]);
                }

                block.Sort();
                Blocks.Add(block);
                i++;
            }

            backTracking(Blocks, 0, new StringBuilder());

            return Result.ToArray();
        }

        private void backTracking(List<List<char>> blocks, int index, StringBuilder sb)
        {
            //base
            if(index == blocks.Count)
            {
                Result.Add(sb.ToString());
                return;
            }

            //logic
            List<char> block = blocks[index];
            for(int i = 0; i < block.Count; i++)
            {
                sb.Append(block[i]);

                backTracking(blocks, index + 1, sb);

                sb.Length = sb.Length - 1;
            }
        }
    }
}
