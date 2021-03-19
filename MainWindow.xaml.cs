using System;
using System.Windows;
using Xceed.Wpf.Toolkit;
using utauPlugin;

namespace LengthRandomizer
{
    public partial class MainWindow : Window
    {
        private UtauPlugin utauPlugin;
        private Random rand;
        string[] args = Environment.GetCommandLineArgs();
        public MainWindow()
        {
            InitializeComponent();
            rand = new Random();
            utauPlugin = new UtauPlugin(args[1]);
            utauPlugin.Input();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void OK(object sender, RoutedEventArgs e)
        {
            foreach (Note note in utauPlugin.note)
            {
                note.SetLength(note.GetLength() + rand.Next(0 - (int)this.amount.Value, (int)this.amount.Value));
            }
            utauPlugin.Output();
            Close();
        }
    }
}
