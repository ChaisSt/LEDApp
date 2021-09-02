using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LEDApp.LedVM;

namespace LEDApp
{
    class LedModel : ObservableObject
    {
        private int _id { get; set; }
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        public string LedPitch { get; set; }

        private string _backgroundColor { get; set; }
        public string BackgroundColor
        {
            get { return _backgroundColor; }
            set 
            { 
                _backgroundColor = value;
                OnPropertyChanged();
            }
        }

        private string _borderColor { get; set; }
        public string BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand LedPressedCommand { get; set; }
        
        public LedModel()
        {
            LedPressedCommand = new RelayCommand(o => SetLedPressed(o));
        }

        void SetLedPressed(object o)
        {
            var color = LedVM.instance.PaintColor;
            var led = string.IsNullOrEmpty(color) ? "White" : color;
            BackgroundColor = led;
            BorderColor = led;

        }
    }

    class ColorModel : ObservableObject
    {
        private string _color { get; set; }
        public string Color
        {
            get { return _color; }
            set
            {
                _color = value;
                OnPropertyChanged();
            }
        }
    }
}
