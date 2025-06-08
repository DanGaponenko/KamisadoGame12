using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamisadoGame12
{
    public class Square
    {
        public string Color { get; set; }
        public bool IsOccupied { get; set; }
        public Square()
        {
            this.Color = string.Empty;
            this.IsOccupied = false;
        }

        public Square(string color, bool isOccupied)
        {
            Color = color;
            IsOccupied = isOccupied;
        }
        public Square(string color)
        {
            this.Color = color;
            this.IsOccupied = false;
        }
    }
}
