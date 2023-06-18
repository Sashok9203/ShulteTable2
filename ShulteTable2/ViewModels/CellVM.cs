using System;
using System.Windows.Input;
using ShulteTable2.Helpers;
namespace ShulteTable2.ViewModels
{
   
    public enum CellColor
    {
        White, Green, Purple, Yellow, Blue, Red
    };

    public enum CellState
    {
        Current, IsWrong,Pressed
    }

    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public class CellVM
    {
        private RelayCommand clickCommand;
        private static Random rnd = new();
        private Action<CellVM>? changed;

        public int Number { get; }
        public CellColor Color { get; set; }
        public CellState State { get; set; }
        public ICommand ClickCommand => clickCommand;
    

        public CellVM(int number) : this(number, GetRandomColor()) { }
        public CellVM(int number,Action<CellVM> change) : this(number) {changed = change; }
        public CellVM(int number, CellColor color)
        {
            Number = number;
            Color = color;
            State = CellState.IsWrong;
            clickCommand = new((o) => mouseClick());
        }

        private static CellColor GetRandomColor() => (CellColor)rnd.Next(Enum.GetValues(typeof(CellColor)).Length);
       
        private void mouseClick()
        {
            if (State == CellState.Current)
            {
                State = CellState.Pressed;
                changed?.Invoke(this);
            }
        }
    }
}
