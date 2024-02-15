using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       public static List<MyButton> buttons = new List<MyButton>();
        MyButton button = new MyButton();
        public bool isCaps = false;
        public int fails=0;
        public string temp_str = "I love programming, I love programming/ I love programming";
        public MainWindow()
        {
            InitializeComponent();
      
        }
       
        private void KeyBoard_KeyDown(object sender, KeyEventArgs e)
        {
            TextFails.Text=fails.ToString();
            string t;
            //RR.Text = temp_str;
            button.DisableActive();
            string temp_text = e.Key.ToString();
            string addtext = "";
            if(temp_text== "Capital")
            {
                if (isCaps) { isCaps = false; }
                else if(!isCaps) { isCaps = true; }
                addtext = "";
            }
            else if(temp_text== "Tab" || temp_text== "LeftShift"
                || temp_text== "RightShift" || temp_text== "LeftCtrl" || temp_text== "LWin" || temp_text== "System" || temp_text== "Apps"
                || temp_text== "RightCtrl") { addtext = ""; }
            else if(temp_text== "Space") { addtext = " "; }
            else if(temp_text == "Back")
            {
                if(TextAutput.Text.Length> 0) { TextAutput.Text = TextAutput.Text.Remove(TextAutput.Text.Length - 1); }
                addtext = "";
            }
            else if(temp_text== "OemComma") { addtext = ","; }
            else if(temp_text== "OemPeriod") { addtext = "."; }
            else if(temp_text== "OemQuestion") { addtext = "/"; }
            else { addtext = temp_text; }

            foreach (var item in buttons)
            {
                if (item.Value == temp_text)
                {
                    button = item;
                    item.MakeActive();
                    if(isCaps)
                    {
                        addtext = addtext.ToUpper();
                        TextAutput.Text += addtext;
                    }
                    else
                    {
                        addtext=addtext.ToLower();
                        TextAutput.Text += addtext;
                    }     
                }
            }
            if (addtext != "")
            {
                t = temp_str[0].ToString();
                temp_str = temp_str.Remove(0, 1);
                //RR.Text = t;
                if (t != addtext) { fails++; }
            }

        }
    }
}
