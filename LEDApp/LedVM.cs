using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace LEDApp
{
    class LedVM
    {
        public PanelModel Panel { get; set; }
        public LedModel LedPressed { get; set; }

        private string _paintColor { get; set; }
        public string PaintColor
        {
            get { return _paintColor; }
            set
            {
                _paintColor = value;
                
            }
        }

        public string LedColor { get; set; }

        public string PanelWidth { get; set; }
        public string PanelHeight { get; set; }
        public string PanelPitch { get; set; }

        public ObservableCollection<ColumnCount> Columns { get; set; }
        public ObservableCollection<RowCount> Rows { get; set; }
        public ObservableCollection<LedModel> Leds { get; set; }

        public RelayCommand LedPressedCommand { get; set; }
        public RelayCommand SetColorCommand { get; set; }
        public RelayCommand SetSizeCommand { get; set; }

        public LedVM()
        {
            Rows = new ObservableCollection<RowCount>();
            Columns = new ObservableCollection<ColumnCount>();
            Leds = new ObservableCollection<LedModel>();

            LedPressedCommand = new RelayCommand(o => SetLedColor(o), o => GetLedPressed());
            SetColorCommand = new RelayCommand(o => SetPaintColor(o), o => GetPaintColor());
            SetSizeCommand = new RelayCommand(o => SetPanelSize(), o => ValidateSize());
        }

        private bool GetLedPressed()
        {
            return true;
        }
        private void SetLedColor(object o)
        {

            LedColor = string.IsNullOrEmpty(PaintColor) ? "White" : PaintColor;
        }

        private bool GetPaintColor()
        {
            return true;
        }

        private void SetPaintColor(object o)
        {
            PaintColor = o.ToString();
        }

        private bool ValidateSize()
        {
            if (string.IsNullOrEmpty(PanelWidth) || string.IsNullOrEmpty(PanelHeight) || string.IsNullOrEmpty(PanelPitch))
            {
                return false;
            }
            else
            {
                if (!IsInt(PanelWidth) && !IsInt(PanelHeight) && !IsInt(PanelPitch))
                {
                    return false;
                }
                return true;
            }
        }

        private void SetPanelSize()
        {
            Panel = new PanelModel
            {
                Height = Convert.ToInt32(PanelHeight),
                Width = Convert.ToInt32(PanelWidth),
                Pitch = Convert.ToDouble(PanelPitch)
            };
            Panel.Area = Panel.Height * Panel.Width;

            CreatePanel();
            CreateGrid();
        }

        private void CreatePanel()
        {
            var ledPitch = Panel.Pitch / 2;

            Leds.Clear();
            for (int i = 0; i < Panel.Area; i++)
            {
                Leds.Add(new LedModel { 
                    Id = i, 
                    BackgroundColor = "#808080",
                    BorderColor = "#696969",
                    LedPitch = Convert.ToString(ledPitch)
                });
            }
        }

        private void CreateGrid()
        {
            Columns.Clear();
            Rows.Clear();

            for (int i = 0; i < Panel.Width; i++)
            {
                Columns.Add( new ColumnCount { Column = (i + 1).ToString()});
            }
            for (int i = 0; i < Panel.Height; i++)
            {
                Rows.Add(new RowCount { Row = (i + 1).ToString()});
            }
        }

        private bool IsInt(string number)
        {
            try
            {
                Convert.ToInt32(number);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
