using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
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
using wirtualna_lonka.classes;
using wirtualna_lonka.classes.animals;
using wirtualna_lonka.classes.plants;
 
namespace wirtualna_lonka
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        World world;
        int CellBorder = 1;
        public Organism SelectedOrganism;

        public GameWindow(int size)
        {
            world = World.GetWorld(size);
            DataContext = this;
            InitializeComponent();
            CreateGrid(world.WorldSize);

            
            world.SpawnInititalOrganisms();
            RenderOrganisms();
        }

        void CreateGrid(int size)
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
                    Border cellBorder = new Border()
                    {
                        BorderBrush = Brushes.Black,
                        BorderThickness = new Thickness(CellBorder),
                        Background = new ImageBrush()
                        {
                            ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/dirt.png")),
                            Stretch = Stretch.Fill
                        }
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
        }

        void RenderOrganisms()
        {
            foreach (Organism org in world.GetOrganisms())
            {
                Image img = new Image()
                {
                    Source = org.image,
                    Stretch = Stretch.Fill
                };

                Grid.SetColumn(img, org.Position.X);
                Grid.SetRow(img, org.Position.Y);
                _MapGrid.Children.Add(img);
            }

            RefreshOrganismsList();
        }

        void RefreshOrganismsList()
        {
            _OrganismsList.Items.Clear();
            foreach (var organism in world.GetOrganisms())
            {
                _OrganismsList.Items.Add(organism);
            }
        }

        void OrganismsListSelection(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ListBox _OrganismsList && _OrganismsList.SelectedItem is Organism selected)
            {
                SelectedOrganism = selected;
                _SelectedOrganism.Content = SelectedOrganism;
            }
        }
    }
}