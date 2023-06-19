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
       
        private static Random rnd = new();
     

        public int Number { get; }
        public CellColor Color { get; set; }
        public bool Current { get; set; }
      
    

        public CellVM(int number) : this(number, GetRandomColor()) { }
      
        public CellVM(int number, CellColor color)
        {
            Number = number;
            Color = color;
            Current = false;
         
        }

        private static CellColor GetRandomColor() => (CellColor)rnd.Next(Enum.GetValues(typeof(CellColor)).Length);
    }
}
