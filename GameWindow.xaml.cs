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
using System.Windows.Shapes;

namespace wirtualna_lonka
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        int MapSize;
        int CellBorder = 1;

        public GameWindow(int size)
        {
            MapSize = size;
            InitializeComponent();
            CreateGride(MapSize);
        }

        void CreateGride(int size)
        {
            Grid MapGrid = _MapGrid;
            MapGrid.RowDefinitions.Clear();
            MapGrid.ColumnDefinitions.Clear();
            MapGrid.Children.Clear();

            for (int i = 0; i < size; i++)
            {
                MapGrid.ColumnDefinitions.Add(new ColumnDefinition()
                {
                    Width = new GridLength(1, GridUnitType.Star)
                });

                MapGrid.RowDefinitions.Add(new RowDefinition()
                {
                    Height = new GridLength(1, GridUnitType.Star)
                });
            }

            CreateBorders();
            CreateButtons();
        }

        void CreateBorders()
        {
            for (int i = 0; i < MapSize; i++)
            {
                for (int j = 0; j < MapSize; j++)
                {
                    Border cellBorder = new Border()
                    {
                        BorderBrush = Brushes.Black,
                        BorderThickness = new Thickness(CellBorder)
                    };

                    Grid.SetColumn(cellBorder, i);
                    Grid.SetRow(cellBorder, j);
                    _MapGrid.Children.Add(cellBorder);
                }
            }
        }

        void CreateButtons()
        {
            for (int i = 0; i < MapSize; i++)
            {
                for (int j = 0; j < MapSize; j++)
                {
                    Button button = new Button()
                    {

                    };

                    Grid.SetColumn(button, i);
                    Grid.SetRow(button, j);
                    _MapGrid.Children.Add(button);
                }
            }
        }

        void GeneratePicture(int size)
        {
            Grid MapGrid = _MapGrid;
            MapGrid.Children.Clear();
            CreateBorders();

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

            Debug.WriteLine(Grid.GetColumn(img));
        }

        string GetImageSource(int index)
        {
            switch (index)
            {
                case 1:
                    return "pack://application:,,,/images/image1.png";
                case 2:
                    return "pack://application:,,,/images/image2.png";
                case 3:
                    return "pack://application:,,,/images/image3.png";
            }

            return "pack://application:,,,/images/image1.png";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GeneratePicture(MapSize);
        }
    }

}
