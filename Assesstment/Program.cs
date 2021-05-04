using System;

namespace Assesstment
{
    class Program
    {
        static void Main(string[] args)
        {
            #region LetterCount
            var letterCount = new LetterCount();
            letterCount.start();
            #endregion
            #region WordSplit
            var wordSplit = new WordSplit(new string[2] { "hellocat", "apple,bat,cat,goodbye,hello,yellow,why" });
            wordSplit.start();
            #endregion
            Console.ReadLine();
        }
    }
}
