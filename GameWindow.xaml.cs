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

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Image img = new Image()
                    {
                        Source = new BitmapImage(new Uri("pack://application:,,,/images/dirt.png")),
                        Stretch = Stretch.Fill
                    };

                    Grid.SetColumn(img, i);
                    Grid.SetRow(img, j);

                    _MapGrid.Children.Add(img);
                }
            }

            CreateBorders();
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
                        BorderThickness = new Thickness(CellBorder),
                        Background = Brushes.Transparent
                    };

                    cellBorder.MouseLeftButtonDown += cellClicked;


                    Grid.SetColumn(cellBorder, i);
                    Grid.SetRow(cellBorder, j);
                    _MapGrid.Children.Add(cellBorder);
                }
            }
        }

        void cellClicked(object sender, EventArgs e)
        {
            int clickedColumn = 0;
            int clickedRow = 0;

            if (sender is Border clicked)
            {
                clickedColumn = Grid.GetColumn(clicked);
                clickedRow = Grid.GetRow(clicked);
            }
            
            GeneratePicture(clickedRow, clickedColumn);
        }

        void GeneratePicture(int row, int col)
        {
            Grid MapGrid = _MapGrid;
            //MapGrid.Children.Clear();
            //CreateBorders();

            Random rng = new Random();

            int ImageIndex = rng.Next(1, 4);
            int cellSize = ((int)((this.Width - 30) / 2 / MapSize));

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
            //GeneratePicture(MapSize);
        }
    }

}
