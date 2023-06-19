using System;
using System.Windows.Input;
using ShulteTable2.Helpers;
namespace ShulteTable2.ViewModels
{
   
    public enum CellColor
    {
        White, Green, Purple, Yellow, Blue, Red
    };

   
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public class CellVM
    {
        private RelayCommand clickCommand;
        private static Random rnd = new();
        private Action<CellVM>? changed;

        public int Number { get; }
        public CellColor Color { get; set; }
        public bool Current { get; set; }
        public ICommand ClickCommand => clickCommand;
    

        public CellVM(int number) : this(number, GetRandomColor()) { }
        public CellVM(int number,Action<CellVM> change) : this(number) {changed = change; }
        public CellVM(int number, CellColor color)
        {
            Number = number;
            Color = color;
            Current = false;
            clickCommand = new((o) => { if (Current) changed?.Invoke(this); });
        }

        private static CellColor GetRandomColor() => (CellColor)rnd.Next(Enum.GetValues(typeof(CellColor)).Length);
    }
}
