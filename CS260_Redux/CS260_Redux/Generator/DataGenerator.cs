using CS260_Redux.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS260_Redux.Generator
{
    public class DataGenerator
    {
        int _MAX_SIZE;
        List<FileDTO> _Table;
        Random _Rand;

        public DataGenerator(int size)
        {
            _MAX_SIZE = size;
            _Table = new List<FileDTO>(1000);

            // Seed Rand
            _Rand = new Random();
        }

        public void GenerateData()
        {
            // Generate data based off the max size
            for (int i = 0; i < _MAX_SIZE; i++)
            {
                FileDTO row = new FileDTO(
                    _Rand.Next(0, 500),
                    "David",
                    "Dog",
                    _Rand.Next(1111111, 9999999));
                _Table.Add(row);
            }
        }

        public void WriteFile(string filename)
        {
            try
            {
                // Serialize Table
                string serializedTable = JsonConvert.SerializeObject(_Table);
                // Write File
                File.WriteAllText(filename, serializedTable);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
            }
        }
    }
}
