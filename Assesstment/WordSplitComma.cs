using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesstment
{
    class WordSplitComma
    {
        private string[] data = new string[2];
        private List<string> dictionary = new List<string>();
        private record Position(string text, int index);

        public WordSplitComma(string[] data)
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
                var temps = text.Split(d);
                if (temps.Length > 1)
                {
                    int index = text.IndexOf(d);
                    positions.Add(new Position(d, index));
                }
            });
            if(positions.Count < 1)
            {
                Console.WriteLine("the string not possible");
            }
            else
            {
                List<string> result = positions.OrderBy(c => c.index).Select(c => c.text).ToList();
                Console.WriteLine(String.Join(",", result));
            }
        }
    }
}
