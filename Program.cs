using System;
using System.ComponentModel;

namespace FodyPropertyChangedCSharp
{
    class VM : INotifyPropertyChanged, INotifyPropertyChanging
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;

        public int Value { get; set; }
        public string Value2 { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var vm = new VM();
            vm.PropertyChanging += Program_PropertyChanging;
            vm.PropertyChanged += Program_PropertyChanged;
            vm.Value = 1;
            vm.Value = 100;
            vm.Value2 = "new";
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }

        private static void Program_PropertyChanging(object sender, PropertyChangingEventArgs e)
        {
            Console.WriteLine($"{e.PropertyName} changing!");
        }

        private static void Program_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Console.WriteLine($"{e.PropertyName} changed!");
        }
    }
}
