using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace wirtualna_lonka
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            int MapSize = 10;

            InitializeComponent();
            CreateGride(MapSize);
            //GeneratePictures(MapSize);
        }

        void CreateGride(int size)
        {
            Grid MapGrid = _MapGrid;
            MapGrid.RowDefinitions.Clear();
            MapGrid.ColumnDefinitions.Clear();
            MapGrid.Children.Clear();

            int cellSize = ((int)((this.Width - 30) / 2 / size));

            for (int i = 0; i < size; i++)
            {
                MapGrid.ColumnDefinitions.Add(new ColumnDefinition()
                {
                    Width = new GridLength(cellSize, GridUnitType.Pixel)
                });

                MapGrid.RowDefinitions.Add(new RowDefinition()
                {
                    Height = new GridLength(cellSize, GridUnitType.Pixel)
                });
            }
        }

        void GeneratePicture(int size)
        {
            Grid MapGrid = _MapGrid;
            MapGrid.Children.Clear();

            Random rng = new Random();

            int row = rng.Next(0, size);
            int col = rng.Next(0, size);
            int ImageIndex = rng.Next(1, 3);
            int cellSize = ((int)((this.Width - 30) / 2 / size));

            Image img = new Image();

            img.Source = new BitmapImage(new Uri(GetImageSource(ImageIndex)));
            img.Width = cellSize;
            img.Height = cellSize;

            Grid.SetRow(img, row);
            Grid.SetColumn(img, col);
            _MapGrid.Children.Add(img);
        }

        void GeneratePictures(int size)
        {
            Random rng = new Random();

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    int ImageIndex = rng.Next(1, 3);

                    Image img = new Image();
                    img.Stretch = Stretch.Fill;

                    switch (ImageIndex)
                    {
                        case 1:
                            img.Source = new BitmapImage(new Uri(GetImageSource(ImageIndex)));
                            break;
                        case 2:
                            img.Source = new BitmapImage(new Uri(GetImageSource(ImageIndex)));
                            break;
                        case 3:
                            img.Source = new BitmapImage(new Uri(GetImageSource(ImageIndex)));
                            break;
                    }

                    Grid.SetRow(img, i);
                    Grid.SetColumn(img, j);

                    _MapGrid.Children.Add(img);
                }
            }
        }

        string GetImageSource(int index)
        {
            switch (index)
            {
                case 1:
                    return "pack://application:,,,/Resources/image1.png";
                case 2:
                    return "pack://application:,,,/Resources/image2.png";
                case 3:
                    return "pack://application:,,,/Resources/image3.png";
            }

            return "pack://application:,,,/Resources/image1.png";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GeneratePicture(10);
        }
    }


}