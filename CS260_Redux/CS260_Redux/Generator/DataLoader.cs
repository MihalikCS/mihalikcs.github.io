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
    public class DataLoader
    {
        List<FileDTO> _TestData;
        string _DataFilename;

        public DataLoader(string testFileName)
        {
            _DataFilename = testFileName;
            _TestData = new List<FileDTO>();
        }

        public void LoadTestData()
        {
            // Get String
            var serializedString = File.ReadAllText(_DataFilename);
            // Deserialize & Load
            _TestData = JsonConvert.DeserializeObject<List<FileDTO>>(serializedString);
        }

        public List<FileDTO> getTestData()
        {
            // Force Load
            if (_TestData.Count <= 0)
                LoadTestData();
            // Return the item
            return _TestData;
        }
    }
}
