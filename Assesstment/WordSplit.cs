using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesstment
{
    public class WordSplit
    {
        private string[] data = new string[2];
        private List<string> dictionary = new List<string>();
        private record Position(string text, int index);

        public WordSplit(string[] data)
        {
            this.data = data;
        }

        public void start()
        {
            string text = data[0];
            //record the world position and make sure after process the sequence remain
            List<Position> positions = new List<Position>();
            dictionary = data[1].Split(',').ToList();
            dictionary.ForEach(d =>
            {
                if (text.Contains(d))
                {
                    int index = text.IndexOf(d);
                    positions.Add(new Position(d, index));
                }
            });
            List<string> result = positions.OrderBy(c => c.index).Select(c => c.text).ToList();
            Console.WriteLine(String.Join(" ", result));
        }
    }
}
