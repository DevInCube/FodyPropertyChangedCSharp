using System;
using System.ComponentModel;

namespace FodyPropertyChangedCSharp
{
    class VM : INotifyPropertyChanged, INotifyPropertyChanging
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;

        public int Value { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var vm = new VM();
            (vm as INotifyPropertyChanging).PropertyChanging += Program_PropertyChanging;
            (vm as INotifyPropertyChanged).PropertyChanged += Program_PropertyChanged;
            vm.Value = 1;
            vm.Value = 100;
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }

        private static void Program_PropertyChanging(object sender, PropertyChangingEventArgs e)
        {
            Console.WriteLine("Value changing!");
        }

        private static void Program_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Console.WriteLine("Value changed!");
        }
    }
}
