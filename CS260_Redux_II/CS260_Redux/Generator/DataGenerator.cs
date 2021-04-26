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
        List<string> _NameDict, _AddressDict;
        Random _Rand;

        public DataGenerator(int size)
        {
            _MAX_SIZE = size;
            _Table = new List<FileDTO>(1000);

            // Dictionaries
            _NameDict = new List<string>()
            {
                "Gary",
                "Bob",
                "George",
                "Sam",
                "Harper",
                "Cora"
            };

            _AddressDict = new List<string>()
            {
                "123 Seasme St",
                "454 Brick Ave",
                "375 Long Point Rd",
                "104 Ridge Ave",
                "1034 Dode Lane"
            };

            // Seed Rand
            _Rand = new Random();
        }

        public void GenerateData()
        {
            // Generate data based off the max size
            for (int i = 0; i < _MAX_SIZE; i++)
            {
                // Generate Indexes for Dictionaries
                int nameIndex = _Rand.Next() % _NameDict.Count;
                if (nameIndex >= _NameDict.Count)
                    throw new ArgumentOutOfRangeException("nameIndex");

                int addressIndex = _Rand.Next() % _AddressDict.Count;
                if (addressIndex >= _AddressDict.Count)
                    throw new ArgumentOutOfRangeException("addressIndex");

                // Generate the DTO row
                FileDTO row = new FileDTO(
                    _Rand.Next(0, 500),
                    _NameDict[nameIndex],
                    _AddressDict[addressIndex],
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
