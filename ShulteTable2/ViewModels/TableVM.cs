using ShulteTable2.Helpers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ShulteTable2.ViewModels
{
    public class TableVM
    {
        private ObservableCollection<CellVM> cells = new ();
        private RelayCommand exitCommand;
        private RelayCommand clickCommand;

        public ICommand Exit => exitCommand;
        public IEnumerable<CellVM> Cells => cells;
        public ICommand ClickCommand => clickCommand;

        public const int EYE_NUMBER = 0;
        public int FirstNumber { get; } = 1;
        public int LastNumber { get; }

        public TableVM(int size)
        {
            clickCommand = new((o) => { cellChangeed(o); });
            exitCommand = new((o) =>  exit());
            LastNumber = size * size - 1;
            GenerateCells();
        }

        private void GenerateCells()
        {
            if(cells.Count !=0)cells.Clear();
            for (int i = FirstNumber; i <= LastNumber; ++i)
                 cells.Add(new(i));
            cells[0].Current = true;
            this.cells.Shuffle();
            cells.Insert(cells.Count / 2, new CellVM(EYE_NUMBER, CellColor.White));
           
        }

        private void cellChangeed(object cell)
        {
            if (cell is CellVM currentCell)
            {
                currentCell.Current = false;
                CellVM? cNext = cells.FirstOrDefault(n => n.Number == currentCell.Number + 1);
                if (cNext != null) cNext.Current = true;
                else
                {
                    exit();
                    GenerateCells();
                }
            }
        }

        private void exit()
        {
            if (MessageBox.Show("Do you want to exit?","Exit",MessageBoxButton.YesNo) == MessageBoxResult.Yes) Application.Current.Shutdown();
        }
    }
}
