using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEDApp
{
    class PanelModel
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public double Pitch { get; set; }
        public int Area { get; set; }

        public List<LedModel> Leds { get; set; }

        public PanelModel()
        {
            Leds = new List<LedModel>();
        }
    }

    class ColumnCount : ObservableObject
    {
        private string _column;
        public string Column
        {
            get { return _column; }
            set
            {
                _column = value;
                OnPropertyChanged();
            }
        }
    }

    class RowCount : ObservableObject
    {
        private string _row;
        public string Row
        {
            get { return _row; }
            set
            {
                _row = value;
                OnPropertyChanged();
            }
        }
    }
}
