using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS260_Redux.Model
{
    public class FileDTO
    {
        public int key { get; set; }
        public String name { get; set; }
        public String address { get; set; }
        public int phoneNumber { get; set; }

        public FileDTO(int k, string n, string a, int p)
        {
            key = k;
            name = n;
            address = a;
            phoneNumber = p;
        }
    }
}
