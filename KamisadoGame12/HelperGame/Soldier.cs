using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamisadoGame12
{
    public class Soldier
    {
        public string BaseColor { get; set; }
        public string Color { get; set; }
        public int SColumn { get; set; }
        public int SRow { get; set; }

        public Soldier()
        {
            BaseColor = string.Empty;
            Color = string.Empty;
            SColumn = 0;
            SRow = 0;
        }

        public Soldier(string baseColor, string color, int SColumn, int SRow)
        {
            BaseColor = baseColor;
            Color = color;
            SColumn = SColumn;
            SRow = SRow;
        }

        public override string ToString()
        {
            string result = this.BaseColor + " " + this.Color + " " + this.SRow + " " + this.SColumn;
            return result;
        }
    }

}
