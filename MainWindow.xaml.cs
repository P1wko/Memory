using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;

namespace Memory
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string firstBtn, secondBtn;
        public int whichOne = 0;
        public Button button1;
        public Button button2;
        public int imgNumber1, imgNumber2;
        public MainWindow()
        {
            InitializeComponent();
            NewGame();
        }

       private void Button_Click(object sender, RoutedEventArgs e)
        { 
            var button = sender as Button;
            Image image = new Image();

            string buttonName = button.Name;
            int y = buttonName[7] - 48; 
            int x = buttonName[9] - 48;
            int imgNumber = 1;
            for (int i = 0; i < 16; i++)
            {
                if (solution[i].x == x && solution[i].y == y) imgNumber = solution[i].img;
            }

            button.Content = image;
            var _imagedirectory = "F:/Michal/Projekt/Saper/Memory/memoryimg/" + imgNumber.ToString() + ".jpg";
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(_imagedirectory, UriKind.Absolute);
            bitmap.EndInit();

            image.Source = bitmap;

            if (whichOne == 0)
            {
                firstBtn = button.Name;
                button1 = button;
                imgNumber1 = imgNumber;
            }

            if (whichOne == 1)
            {
                secondBtn = button.Name;
                button2 = button;
                imgNumber2 = imgNumber;
            }

            if(whichOne < 2) whichOne++;
            else
            {
                if(IsMatching())
                {
                    button1.Content = "X";
                    button2.Content = "X";
                }
                else
                {
                    button1.Content = "?";
                    button2.Content = "?";
                }
                button1 = button;
                imgNumber1 = imgNumber;
                whichOne = 1;
            }
        }

        struct attach
        {
            public int img;
            public int? y, x;
        }
        attach[] solution = new attach[16];

        private void NewGame()
        {
            var rand = new Random();

            for (int i = 0; i < 16;)
            {
                solution[i].img = i + 1;
                bool isNew = true;
                int x = rand.Next(4);
                int y = rand.Next(4);
                for (int j = 0; j < 16; j++)
                {
                    if (solution[j].x == x && solution[j].y == y)
                    {
                        isNew = false;
                        break;
                    }
                }
                if(isNew == true)
                {
                    solution[i].x = x;
                    solution[i].y = y;
                    i++;
                }
            }
        }

        bool IsMatching()
        {
            if ((imgNumber1 == 1 && imgNumber2 == 2) || (imgNumber1 == 3 && imgNumber2 == 4) || (imgNumber1 == 5 && imgNumber2 == 6) || (imgNumber1 == 7 && imgNumber2 == 8) || (imgNumber1 == 9 && imgNumber2 == 10) || (imgNumber1 == 11 && imgNumber2 == 12) || (imgNumber1 == 13 && imgNumber2 == 14) || (imgNumber1 == 15 && imgNumber2 == 16))
                return true;
            else return false;
        }
    }
}
