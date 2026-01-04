using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManagementSystem.Model
{
    public class Apartment
    {

        public int Id { get; set; }

        public string ApertmentNo { get; set; }
        public int Floor { get; set; }
        public bool IsOccupied { get; set; }


}
}
