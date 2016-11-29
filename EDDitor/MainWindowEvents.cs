using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace EDDitor
{
    public partial class MainWindow : Window
    {
        //events textBlock
        private void closeFile(object sender, RoutedEventArgs e)
        {
            StackPanel spClosingFile = getCurrentFile(sender as Button).spTextSpace; //get needed parent element

            for (int i = 0; i < openedFiles.Count; i++)
            {
                if (openedFiles[i].spTextSpace == spClosingFile)
                {
                    spMain.Children.Remove(openedFiles[i].spTextSpace);
                    openedFiles.Remove(openedFiles[i]);
                }
            }
        }
        private void saveFile(object sender, RoutedEventArgs e)
        {
            //here
        }
        private void saveFileAs(object sender, RoutedEventArgs e)
        {
            //here
        }
    }
}