using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace csharp_scrabble_challenge.Main
{
    public class Scrabble
    {
        string word;
        private Dictionary<char, int> letterValues = new Dictionary<char, int>(){
            {'A', 1}, {'E', 1}, {'I', 1}, {'O', 1}, {'U', 1}, {'L', 1}, {'N', 1}, {'R', 1}, {'S', 1}, {'T', 1},
            {'D', 2}, {'G', 2},
            {'B', 3}, {'C', 3}, {'M', 3}, {'P', 3},
            {'F', 4}, {'H', 4}, {'V', 4}, {'W', 4}, {'Y', 4},
            {'K', 5},
            {'J', 8}, {'X', 8},
            {'Q', 10}, {'Z', 10}
        };

        public Scrabble(string word)
        {
            this.word = word.Trim().ToUpper();
        }

        public int score()
        {
            int score = 0;
            for (int i = 0; i < this.word.Length; i++)
            {
                char letter = this.word.ElementAt(i);
                if (this.letterValues.ContainsKey(letter))
                {
                    // Check if letter is not first or last letter of the word
                    if (i > 0 && i < this.word.Length - 1)
                    {
                        if (this.word.ElementAt(i - 1) == '{' && this.word.ElementAt(i + 1) == '}')
                        {
                            // Double letter score, example for 'o' in d{o}g
                            score += this.letterValues[letter] * 2;
                        }
                        else if (this.word.ElementAt(i - 1) == '[' && this.word.ElementAt(i + 1) == ']')
                        {
                            // Triple letter score, example for 'o' in d[o]g
                            score += this.letterValues[letter] * 3;
                        }
                        else
                        {
                            score += this.letterValues[letter];
                        }
                    }
                    else
                    {
                        score += this.letterValues[letter];
                    }

                }
            }

            // Check for double word
            if (this.word.StartsWith("{") && this.word.EndsWith("}"))
            {
                score *= 2;
            }
            // Check for triple word
            else if (this.word.StartsWith("[") && this.word.EndsWith("]"))
            {
                score *= 3;
            }
            return score;
        }
    }
}
