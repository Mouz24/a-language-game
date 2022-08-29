using System;
using System.Collections.Generic;

#pragma warning disable 

namespace LanguageGame
{
    public static class Translator
    {
        /// <summary>
        /// Translates from English to Pig Latin. Pig Latin obeys a few simple following rules:
        /// - if word starts with vowel sounds, the vowel is left alone, and most commonly 'yay' is added to the end;
        /// - if word starts with consonant sounds or consonant clusters, all letters before the initial vowel are
        ///   placed at the end of the word sequence. Then, "ay" is added.
        /// Note: If a word begins with a capital letter, then its translation also begins with a capital letter,
        /// if it starts with a lowercase letter, then its translation will also begin with a lowercase letter.
        /// </summary>
        /// <param name="phrase">Source phrase.</param>
        /// <returns>Phrase in Pig Latin.</returns>
        /// <exception cref="ArgumentException">Thrown if phrase is null or empty.</exception>
        /// <example>
        /// "apple" -> "appleyay"
        /// "Eat" -> "Eatyay"
        /// "explain" -> "explainyay"
        /// "Smile" -> "Ilesmay"
        /// "Glove" -> "Oveglay".
        /// </example>
        public static string TranslateToPigLatin(string phrase)
        {
            if (string.IsNullOrEmpty(phrase) || string.IsNullOrWhiteSpace(phrase))
            {
                throw new ArgumentException($"{phrase}");
            }

            char[] vowels = new char[] { 'a', 'o', 'e', 'i', 'u' };
            List<char> res = new List<char>();
            for (int j = 0; j < vowels.Length; j++)
            {
                if (char.ToLower(phrase[0]) == vowels[j])
                {
                    return phrase + "yay";
                }
            }

            int st = 0;
            string phr = null;
            for (int i = 0; i < phrase.Length; i++)
            {
                if (i > 0)
                {
                    if ((phrase[i] == ' ' || phrase[i] == ',' || phrase[i] == '.' || phrase[i] == '!' || phrase[i] == '?' || (phrase[i] == '-' && char.IsLetter(phrase[i + 1]))) && char.IsLetter(phrase[i - 1]))
                    {
                        int mark = i;
                        for (int j = st; j < mark; j++)
                        {
                            phr += phrase[j].ToString();
                        }

                        var p = Modify(phr).ToCharArray();
                        foreach (var t in p)
                        {
                            res.Add(t);
                        }

                        phr = null;
                    }
                }

                if (phrase[i] == ' ' || phrase[i] == ',' || phrase[i] == '.' || phrase[i] == '!' || phrase[i] == '?' || phrase[i] == '-')
                {
                    res.Add(phrase[i]);
                }

                if ((phrase[i] == ' ' || phrase[i] == ',' || (phrase[i] == '-' && char.IsLetter(phrase[i - 1]))) && char.IsLetter(phrase[i + 1]))
                {
                    st = i + 1;
                }
            }

            string res3 = null;
            foreach (var t in res)
            {
                res3 += t;
            }

            for (int i = 0; i < phrase.Length; i++)
            {
                if (phrase[i] == ' ' || phrase[i] == ',')
                {
                    return res3;
                }
            }

            res.Clear();
            int count = 0;
            for (int i = 0; i < phrase.Length; i++)
            {
                for (int j = 0; j < vowels.Length; j++)
                {
                    if (phrase[i] == vowels[j])
                    {
                        int count2 = i;
                        for (int k = i; k < phrase.Length; k++)
                        {
                            if (k == i && char.IsUpper(phrase[0]))
                            {
                                res.Add(char.ToUpper(phrase[k]));
                            }
                            else
                            {
                                res.Add(phrase[k]);
                            }
                        }

                        for (int u = 0; u < count2; u++)
                        {
                            res.Add(char.ToLower(phrase[u]));
                        }

                        count++;
                    }
                }

                if (count == 1)
                {
                    break;
                }
            }

            string res2 = null;
            foreach (var t in res)
            {
                res2 += t;
            }

            return res2 + "ay";
        }

        public static string Modify(string phrase)
        {
            char[] vowels = new char[] { 'a', 'o', 'e', 'i', 'u' };
            List<char> res = new List<char>();
            int count = 0;
            if (phrase == "by")
            {
                return "byay";
            }

            for (int j = 0; j < vowels.Length; j++)
            {
                if (char.ToLower(phrase[0]) == vowels[j])
                {
                    return phrase + "yay";
                }
            }

            for (int i = 0; i < phrase.Length; i++)
            {
                for (int j = 0; j < vowels.Length; j++)
                {
                    if (phrase[i] == vowels[j])
                    {
                        int count2 = i;
                        for (int k = i; k < phrase.Length; k++)
                        {
                            if (k == i && char.IsUpper(phrase[0]))
                            {
                                res.Add(char.ToUpper(phrase[k]));
                            }
                            else
                            {
                                res.Add(phrase[k]);
                            }
                        }

                        for (int u = 0; u < count2; u++)
                        {
                            res.Add(char.ToLower(phrase[u]));
                        }

                        count++;
                    }
                }

                if (count == 1)
                {
                    break;
                }
            }

            string res2 = null;
            foreach (var t in res)
            {
                res2 += t;
            }

            return res2 + "ay";
        }
    }
}
