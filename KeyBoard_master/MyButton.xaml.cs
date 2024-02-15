using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KeyBoard_master
{
    /// <summary>
    /// Логика взаимодействия для MyButton.xaml
    /// </summary>
    public partial class MyButton : UserControl, INotifyPropertyChanged
    {
        public string Text { get; set; }
        public string Value { get; set; }
        string bgColor;

        public event PropertyChangedEventHandler PropertyChanged;


        public string BgColor
        {
            get => bgColor;
            set
            {
                bgColor = value;
                ChangingProperty("BgColor");
               
            }
        }

        public MyButton()
        {
            InitializeComponent();
           
            this.DataContext = this;
            MainWindow.buttons.Add(this);

        }
        public void ChangingProperty(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        string tempBgColor;
        public void MakeActive()
        {
            tempBgColor = BgColor;
            BgColor = "Red";
        }

        public void DisableActive()
        {
            if (tempBgColor != null)
                BgColor = tempBgColor;
        }
    }
}

