using System;
using System.Collections.Generic;
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
        public string BackgroundColor { get; set; }
        public string BorderColor { get; set; }

        public RelayCommand LedPressedCommand { get; set; }
        
        public LedModel()
        {
            LedPressedCommand = new RelayCommand(o => SetLedPressed(o));
        }

        void SetLedPressed(object o)
        {
            //LedVM.SetLedPressed(o);
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
